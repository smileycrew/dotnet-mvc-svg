using dotnet_mvc_svg.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_mvc_svg.Data;
public class dotnet_mvc_svgDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Comment> Comment { get; set; }
    public DbSet<Contestant> Contestant { get; set; }

    public dotnet_mvc_svgDbContext(DbContextOptions<dotnet_mvc_svgDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>().HasData(new Comment
        {
            Id = 1,
            ContestantId = 1,
            DateAdded = DateTime.Now,
            Message = "#Superman is the best that ever lived!"
        });

        modelBuilder.Entity<Contestant>().HasData(new Contestant
        {
            Id = 1,
            Name = "Superman"
        });
    }
}