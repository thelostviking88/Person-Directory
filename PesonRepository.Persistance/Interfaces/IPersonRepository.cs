using PersonDirectory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Interfaces;

public interface IPersonRepository 
{
    Task<IEnumerable<Person>> GetAllPersonsAsync();
    Task<Person> GetPersonByIdAsync(int personId);
    Task<Person> GetPersonWithDetailsAsync(int personId);
    Task<IEnumerable<Person>> GetByCondition(Expression<Func<Person, bool>> expression);
    Task CreatePersonAsync(Person person);
    void UpdatePerson(Person person);
    void DeletePerson(Person person);
}
