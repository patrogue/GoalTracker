using GoalTracker.Domain.Entities;

namespace GoalTracker.Application.Abstractions;

public interface IPersonRepositry
{
    public Task CreatePerson(Person person);
    public Task DeletePerson(Guid id);
    public Task UpdatePerson(Guid id, string firstName, string lastName, string email);

    public Task<ICollection<Person>> GetAllPersons();
    public Task<Person> GetPersonById(Guid id);
}