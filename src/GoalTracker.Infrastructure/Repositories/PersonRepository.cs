using GoalTracker.Domain.Entities;
using GoalTracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Infrastructure.Repositories;

public class PersonRepository(GoalTrackerContext context) : IPersonRepositry
{
    private readonly GoalTrackerContext _context = context;

    public async Task CreatePerson(Person person)
    {
        _context.Person.Add(person);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerson(Guid id)
    {
        Person? person = _context.Person.FirstOrDefault(p => p.Id == id);

        // Throw exception if person does not exist
        if (person is null)
        {
            return;
        }

        _context.Person.Remove(person);

        await _context.SaveChangesAsync();
    }

    public async Task UpdatePerson(Guid id, string firstName, string lastName, string email)
    {
        Person? person = _context.Person.FirstOrDefault(p => p.Id == id);

        // Throw exception if person does not exist
        if (person is null)
        {
            return;
        }

        person.FirstName = firstName;
        person.FirstName = lastName;
        person.Email = email;

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Person>> GetAllPersons()
    {
        return await _context.Person.ToListAsync();
    }

    public async Task<Person> GetPersonById(Guid id)
    {
        // Throw exception if person does not exist
        return await _context.Person.FirstOrDefaultAsync(p => p.Id == id);
    }
}