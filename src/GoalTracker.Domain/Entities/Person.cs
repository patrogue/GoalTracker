namespace GoalTracker.Domain.Entities;

public sealed class Person
{
    public Guid PersonId { get; set; }
    public string Forename { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}