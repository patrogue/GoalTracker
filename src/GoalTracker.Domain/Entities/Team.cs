namespace GoalTracker.Domain.Entities;

public sealed class Team
{
    public Guid TeamId { get; set; }
    public Guid ClubId { get; set; }
    public string TeamName { get; set; } = string.Empty;

    public required Club Club { get; set; }
    public required ICollection<Match> HomeMatches { get; set; }
    public required ICollection<Match> AwayMatches { get; set; }
}