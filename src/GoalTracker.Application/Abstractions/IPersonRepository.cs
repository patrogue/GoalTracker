using GoalTracker.Domain.Entities;

namespace GoalTracker.Application.Abstractions;

public interface IPersonRepositry
{
    public Task CreatePerson(Person person);
    public Task DeletePerson(Guid id);
    public Task UpdatePerson(Guid id, string firstName, string lastName, string email);

    public Task<ICollection<Person>> GetAllPersonsWithFirstName(string firstName);
    public Task<ICollection<Person>> GetAllPersonsWithLastName(string lastName);
    public Task<ICollection<Person>> GetAllPersons();

    public Task<Person> GetPersonByFullName(string firstName, string lastName);
    public Task<Person> GetPersonByEmail(string email);
    public Task<Person> GetPersonById(Guid id);
}
