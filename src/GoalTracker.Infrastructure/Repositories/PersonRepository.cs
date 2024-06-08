using GoalTracker.Domain.Entities;
using GoalTracker.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace GoalTracker.Infrastructure.Repositories;

public class PersonRepository(GoalTrackerContext context) : IPersonRepositry
{
    private readonly GoalTrackerContext _context = context;

    public async Task CreatePerson(Person person)
    {
        if (!_context.Person.Any(p => p.FirstName == person.FirstName && p.LastName == person.LastName))
        {
            throw new Exception($"There already exists a Person with full name: {person.FirstName} {person.LastName}");
        }

        if (!_context.Person.Any(p => p.Email == person.Email))
        {
            throw new Exception($"There already exists a Person with email: {person.Email}");
        }

        _context.Person.Add(person);

        await _context.SaveChangesAsync();
    }

    public async Task DeletePerson(Guid id)
    {
        Person person = _context.Person.FirstOrDefault(p => p.Id == id)
            ?? throw new Exception($"There is no Person with id: {id}");

        _context.Person.Remove(person);

        await _context.SaveChangesAsync();
    }

    public async Task UpdatePerson(Guid id, string firstName, string lastName, string email)
    {
        if (!_context.Person.Any(p => p.FirstName == firstName && p.LastName == lastName))
        {
            throw new Exception($"There already exists a Person with full name: {firstName} {lastName}");
        }

        if (!_context.Person.Any(p => p.Email == email))
        {
            throw new Exception($"There already exists a Person with email: {email}");
        }

        Person person = _context.Person.FirstOrDefault(p => p.Id == id)
            ?? throw new Exception($"There is no Person with id: {id}");

        person.FirstName = firstName;
        person.FirstName = lastName;
        person.Email = email;

        _context.Person.Update(person);

        await _context.SaveChangesAsync();
    }

    public async Task<ICollection<Person>> GetAllPersonsWithFirstName(string firstName)
    {
        return await _context.Person.Where(p => p.FirstName == firstName).ToListAsync();
    }

    public async Task<ICollection<Person>> GetAllPersonsWithLastName(string lastName)
    {
        return await _context.Person.Where(p => p.LastName == lastName).ToListAsync();
    }

    public async Task<ICollection<Person>> GetAllPersons()
    {
        return await _context.Person.ToListAsync();
    }

    public async Task<Person> GetPersonByFullName(string firstName, string lastName)
    {
        return await _context.Person.FirstOrDefaultAsync(p => p.FirstName == firstName && p.LastName == lastName)
            ?? throw new Exception($"There is no Person with full name: {firstName} {lastName}");
    }

    public async Task<Person> GetPersonByEmail(string email)
    {
        return await _context.Person.FirstOrDefaultAsync(p => p.Email == email)
            ?? throw new Exception($"There is no Person with email: {email}");
    }

    public async Task<Person> GetPersonById(Guid id)
    {
        return await _context.Person.FirstOrDefaultAsync(p => p.Id == id)
            ?? throw new Exception($"There is no Person with id: {id}");
    }
}
