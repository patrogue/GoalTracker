namespace GoalTracker.Domain.Entities;

public sealed class Match
{
    public Guid Id { get; set; }

    public Guid HomeTeamId { get; set; }
    public Guid AwayTeamId { get; set; }

    public required Team HomeTeam { get; set; }
    public required Team AwayTeam { get; set; }
}