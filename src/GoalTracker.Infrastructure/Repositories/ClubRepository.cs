using GoalTracker.Domain.Entities;
using GoalTracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Infrastructure.Repositories;

public class ClubRepository(GoalTrackerDbContext context) : IClubRepository
{
    private readonly GoalTrackerDbContext _context = context;

    public async Task CreateClub(Club club)
    {
        _context.Clubs.Add(club);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteClub(Guid clubId)
    {
        Club? club = _context.Clubs.FirstOrDefault(c => c.Id == clubId);

        // Throw exception if club does not exist
        if (club is null)
        {
            return;
        }

        _context.Clubs.Remove(club);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateClub(Guid id, string name, string tag, ICollection<Team> teams)
    {
        Club? club = _context.Clubs.FirstOrDefault(c => c.Id == id);

        // Throw exception if club does not exist
        if (club is null)
        {
            return;
        }

        club.Name = name;
        club.Tag = tag;
        club.Teams = teams;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Club>> GetAllClubs()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetClubById(Guid id)
    {
        // Throw exception if club does not exist
        return await _context.Clubs.FirstOrDefaultAsync(c => c.Id == id);
    }
}