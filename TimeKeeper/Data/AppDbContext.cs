using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Models;

namespace TimeKeeper.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Timing> Timings { get; set; }
    public DbSet<Reserve> Reservation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Timing>()
            .HasOne<Employee>(e => e.Employee)
            .WithMany(t => t.TimingInfo)
            .HasForeignKey(p => p.EmployeeId);
    }
}
