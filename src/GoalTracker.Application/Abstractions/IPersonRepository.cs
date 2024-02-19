using GoalTracker.Domain.Entities;

namespace GoalTracker.Application.Abstractions;

public interface IPersonRepositry
{
    public Task CreatePerson(Person person);
    public Task DeletePerson(int personId);
    public Task UpdatePerson(int personId, string forename, string surname, string email);

    public Task<ICollection<Person>> GetAllPersons();
    public Task<Person> GetPersonById(int personId);
}