using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Models;
using System.Linq.Expressions;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// Person repository
/// </summary>
public interface IPersonRepository
{
    /// <summary>
    /// Get short model by person id
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    Task<Person> GetByIdAsync(int personId, CancellationToken cancellationToken);

    /// <summary>
    /// Get person with city, phones and connected people by id
    /// </summary>
    /// <param name="personId"></param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    Task<Person> GetPersonWithDetailsAsync(int personId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets person
    /// </summary>
    /// <param name="personId">The person identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<Person> GetAsync(int personId, CancellationToken cancellationToken);

    /// <summary>
    /// Filters the by condition.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>list of persons</returns>
    Task<IEnumerable<Person>> GetByCondition(Expression<Func<Person, bool>> expression, CancellationToken cancellationToken);

    /// <summary>
    /// Creates person.
    /// </summary>
    /// <param name="person">The person model</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task CreateAsync(Person person, CancellationToken cancellationToken);

    /// <summary>
    /// Update person
    /// </summary>
    /// <param name="person"></param>
    /// <param name="cancellationToken">cancellation token</param>
    void Update(Person person);

    /// <summary>
    /// Delete person
    /// </summary>
    /// <param name="person"></param>
    /// <param name="cancellationToken">cancellation token</param>
    void Delete(Person person);

    /// <summary>
    /// Detailed Search
    /// </summary>
    /// <param name="searchRequest"></param>
    /// <returns></returns>
    IQueryable<Person> DetailedSearch(PersonSearchRequestDto searchRequest);
}
