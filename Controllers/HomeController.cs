using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_mvc_svg.Models;
using dotnet_mvc_svg.Data;
using dotnet_mvc_svg.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace dotnet_mvc_svg.Controllers;

public class HomeController : Controller
{
    private readonly dotnet_mvc_svgDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(dotnet_mvc_svgDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Comment> comments = _context.Comment.Include((comment) => comment.Contestant).ToList();
        List<Contestant> contestants = _context.Contestant.ToList();

        HomeDTO homeDTO = new()
        {
            Comments = comments.Select((comment) => new CommentDTO
            {
                Id = comment.Id,
                Contestant = new()
                {
                    Id = comment.Contestant.Id,
                    Name = comment.Contestant.Name
                },
                ContestantId = comment.ContestantId,
                DateAdded = comment.DateAdded,
                Message = comment.Message
            }).ToList(),
            Contestants = contestants.Select((contestant) => new ContestantDTO
            {
                Id = contestant.Id,
                Name = contestant.Name
            }).ToList(),
            UserComment = ""
        };

        return View(homeDTO);
    }

    [HttpPost]
    public IActionResult Index(string userComment)
    {
        // goal of this method is JUST to take the data then save it
        // eventhing in between needs to be done elsewhere
        if (userComment == "") return RedirectToAction();

        string loweredCaseComment = ToLowerCase(userComment);
        // TODO EXTRACT CONTESTANT
        string extractedContestant = ExtractContestant(loweredCaseComment);

        // TODO METHOD TO FIND CONTESTANT
        if (CheckForExistingContestant(extractedContestant))
        {
            Contestant contestant = FindContestant(extractedContestant);
            // IF CONTESTANT WAS FOUND
            Comment newComment = new()
            {
                ContestantId = contestant.Id,
                Message = loweredCaseComment
            };

            _context.Comment.Add(newComment);
            _context.SaveChanges();
        }

        return RedirectToAction();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public bool CheckForExistingContestant(string newContestantName)
    {
        Contestant? contestant = _context.Contestant.FirstOrDefault((contestant) => contestant.Name.ToLower() == newContestantName);

        if (contestant == null) return false;

        return true;
    }

    public string ExtractContestant(string comment)
    {
        string pattern = @"#(\w+)";
        string contestant = Regex.Match(comment, pattern).Value.Replace("#", "").ToLower();

        return contestant;
    }

    public Contestant FindContestant(string contestantName)
    {
        Contestant? contestant = _context.Contestant.FirstOrDefault((contestant) => contestant.Name.ToLower() == contestantName);

        if (contestant == null) throw new Exception();

        return contestant;
    }

    public string ToLowerCase(string comment)
    {
        string loweredCaseComment = comment.ToLower();

        return loweredCaseComment;
    }

}
