using GoalTracker.Domain.Entities;

namespace GoalTracker.Application.Abstractions;

public interface IPersonRepositry
{
    public Task CreatePerson(Person person);
    public Task DeletePerson(Guid personId);
    public Task UpdatePerson(Guid personId, string forename, string surname, string email);

    public Task<ICollection<Person>> GetAllPersons();
    public Task<Person> GetPersonById(Guid personId);
}