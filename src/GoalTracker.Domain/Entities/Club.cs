namespace GoalTracker.Domain.Entities;

public sealed class Club
{
    public Guid ClubId { get; set; }
    public string ClubName { get; set; } = string.Empty;

    public required ICollection<Team> Teams { get; set; }
}