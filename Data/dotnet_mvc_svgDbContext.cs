using DotnetMvcSvg.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetMvcSvg.Data;
public class DotnetMvcSvgDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<Comment> Comment { get; set; }
    public DbSet<Contestant> Contestant { get; set; }

    public DotnetMvcSvgDbContext(DbContextOptions<DotnetMvcSvgDbContext> context, IConfiguration config) : base(context)
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

        modelBuilder.Entity<Contestant>().HasData(
        [
            new()
            {
                Id = 1,
                Name = "Superman"
            },
            new()
            {
                Id = 2,
                Name = "Goku"
            }
        ]);
    }
}