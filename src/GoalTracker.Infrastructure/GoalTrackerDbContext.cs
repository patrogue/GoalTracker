using Microsoft.EntityFrameworkCore;
using GoalTracker.Domain.Entities;

namespace GoalTracker.Infrastructure;

public class GoalTrackerDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Club> Clubs { get; set; }
    public DbSet<Person> Person { get; set; }
}