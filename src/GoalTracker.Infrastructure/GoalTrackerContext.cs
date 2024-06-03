using Microsoft.EntityFrameworkCore;
using GoalTracker.Domain.Entities;

namespace GoalTracker.Infrastructure;

public class GoalTrackerContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Person> Person { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Team>(team =>
        {
            team.HasMany(t => t.HomeMatches)
                .WithOne(t => t.HomeTeam)
                .HasForeignKey(t => t.HomeTeamId)
                .IsRequired();

            team.HasMany(t => t.AwayMatches)
                .WithOne(t => t.AwayTeam)
                .HasForeignKey(t => t.AwayTeamId)
                .IsRequired();
        });
    }
}