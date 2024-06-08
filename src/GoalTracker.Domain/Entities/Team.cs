namespace GoalTracker.Domain.Entities;

public sealed class Team
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;

    public Guid ClubId { get; set; }

    public required Club Club { get; set; }
    public required ICollection<Match> HomeMatches { get; set; }
    public required ICollection<Match> AwayMatches { get; set; }
}
