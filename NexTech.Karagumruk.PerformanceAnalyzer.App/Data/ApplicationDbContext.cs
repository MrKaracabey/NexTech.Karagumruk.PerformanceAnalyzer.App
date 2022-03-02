using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NexTech.Karagumruk.PerformanceAnalyzer.App.Models;

namespace NexTech.Karagumruk.PerformanceAnalyzer.App.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<PlayerTest> PlayerTest { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PlayerTest>()
            .HasKey(bc => new { bc.PlayerId, bc.TestId });  
        modelBuilder.Entity<PlayerTest>()
            .HasOne(bc => bc.Player)
            .WithMany(b => b.PlayerTests)
            .HasForeignKey(bc => bc.PlayerId);  
        modelBuilder.Entity<PlayerTest>()
            .HasOne(bc => bc.Test)
            .WithMany(c => c.PlayerTests)
            .HasForeignKey(bc => bc.TestId);
    }
}