using Microsoft.EntityFrameworkCore;
using GoalTracker.Domain.Entities;

namespace GoalTracker.Infrastructure;

public class PersonDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Person> Person { get; set; }
}