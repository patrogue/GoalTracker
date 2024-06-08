using GoalTracker.Domain.Entities;
using GoalTracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Infrastructure.Repositories;

public class ClubRepository(GoalTrackerContext context) : IClubRepository
{
    private readonly GoalTrackerContext _context = context;

    public async Task CreateClub(Club club)
    {
        if (!_context.Clubs.Any(c => c.Name == club.Name))
        {
            throw new Exception($"There already exists a Club with name: {club.Name}");
        }

        if (!_context.Clubs.Any(c => c.Tag == club.Tag))
        {
            throw new Exception($"There already exists a Club with tag: {club.Tag}");
        }

        _context.Clubs.Add(club);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteClub(Guid id)
    {
        Club club = _context.Clubs.FirstOrDefault(c => c.Id == id)
            ?? throw new Exception($"There is no Club with id: {id}");

        _context.Clubs.Remove(club);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateClub(Guid id, string name, string tag, ICollection<Team> teams)
    {
        if (!_context.Clubs.Any(c => c.Name == name))
        {
            throw new Exception($"There already exists a Club with name: {name}");
        }

        if (!_context.Clubs.Any(c => c.Tag == tag))
        {
            throw new Exception($"There already exists a Club with tag: {tag}");
        }

        Club club = _context.Clubs.FirstOrDefault(c => c.Id == id)
            ?? throw new Exception($"There is no Club with id: {id}");

        club.Name = name;
        club.Tag = tag;
        club.Teams = teams;

        _context.Clubs.Update(club);

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Club>> GetAllClubs()
    {
        return await _context.Clubs.ToListAsync();
    }

    public async Task<Club> GetClubByName(string name)
    {
        return await _context.Clubs.FirstOrDefaultAsync(c => c.Name == name)
            ?? throw new Exception($"There is no Club with name: {name}");
    }

    public async Task<Club> GetClubByTag(string tag)
    {
        return await _context.Clubs.FirstOrDefaultAsync(c => c.Tag == tag)
            ?? throw new Exception($"There is no Club with tag: {tag}");
    }

    public async Task<Club> GetClubById(Guid id)
    {
        return await _context.Clubs.FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new Exception($"There is no Club with id: {id}");
    }
}
