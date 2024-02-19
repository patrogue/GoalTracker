using GoalTracker.Domain.Entities;
using GoalTracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Infrastructure.Repositories;

public class PersonRepository(PersonDbContext context) : IPersonRepositry
{
    private readonly PersonDbContext _context = context;

    public async Task CreatePerson(Person person)
    {
        _context.Person.Add(person);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerson(int personId)
    {
        Person? person = _context.Person.FirstOrDefault(p => p.Id == personId);

        // Throw exception if person does not exist
        if (person is null)
        {
            return;
        }

        _context.Person.Remove(person);

        await _context.SaveChangesAsync();
    }

    public async Task UpdatePerson(int personId, string forename, string surname, string email)
    {
        Person? person = _context.Person.FirstOrDefault(p => p.Id == personId);

        // Throw exception if person does not exist
        if (person is null)
        {
            return;
        }

        person.Forename = forename;
        person.Surname = surname;
        person.Email = email;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Person>> GetAllPersons()
    {
        return await _context.Person.ToListAsync();
    }

    public async Task<Person> GetPersonById(int personId)
    {
        // Throw exception if person does not exist
        return await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
    }
}