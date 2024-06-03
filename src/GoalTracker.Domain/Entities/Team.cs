namespace GoalTracker.Domain.Entities;

public sealed class Team
{
    public Guid TeamId { get; set; }
    public Guid ClubId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string TeamTag { get; set; } = string.Empty;

    public required Club Club { get; set; }
    public required ICollection<Match> Matches { get; set; }
}