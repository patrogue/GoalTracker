using GoalTracker.Domain.Entities;

namespace GoalTracker.Application.Abstractions;

public interface IClubRepository
{
    public Task CreateClub(Club club);
    public Task DeleteClub(Guid id);
    public Task UpdateClub(Guid id, string name, string tag, ICollection<Team> teams);

    public Task<ICollection<Club>> GetAllClubs();
    public Task<Club> GetClubById(Guid id);
}