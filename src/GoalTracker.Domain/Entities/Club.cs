namespace GoalTracker.Domain.Entities;

public sealed class Club
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;

    public required ICollection<Team> Teams { get; set; }
}
