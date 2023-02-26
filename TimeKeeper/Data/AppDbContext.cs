using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Models;

namespace TimeKeeper.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Timing> Timings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Timing>().HasData(
            new Timing
            {
                CheckIn = DateTime.UtcNow,
                CheckOut = DateTime.UtcNow.AddHours(3),
                IsWorking = false,
                Schedule = new List<DayOfWeek>() { DayOfWeek.Monday , DayOfWeek.Friday, DayOfWeek.Tuesday, DayOfWeek.Thursday},
                UserName = "zeus",
                NormalizedUserName = "ZEUS"
                
            },
            new Timing()
            {
                CheckIn = DateTime.UtcNow,
                CheckOut = DateTime.UtcNow.AddHours(7),
                IsWorking = false,
                Schedule = new List<DayOfWeek>() { DayOfWeek.Saturday , DayOfWeek.Sunday},
                UserName = "riot",
                NormalizedUserName = "RIOT"
            }
        );
    }
}