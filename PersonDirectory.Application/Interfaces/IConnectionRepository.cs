using PersonDirectory.Domain.Models;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// Connection Repository
/// </summary>
public interface IConnectionRepository
{  
    /// <summary>
    /// Create connection
    /// </summary>
    /// <param name="personConnection">person connection model</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns></returns>
    Task CreateConnectionAsync(PersonConnection personConnection, CancellationToken cancellationToken);

    /// <summary>
    /// Delete connection
    /// </summary>
    /// <param name="personConnection">person connection model</param>
    /// <param name="cancellationToken">cancellation token</param>
    void DeleteConnection(PersonConnection personConnection);

    /// <summary>
    /// Get connection by id
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>Person Connection model</returns>
    Task<PersonConnection> GetByIdAsync(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Get connection by persons
    /// </summary>
    /// <param name="mainPersonId">main person id</param>
    /// <param name="connectedPersonId">connected person id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>Person Connection model</returns>
    Task<PersonConnection> GetConnectionAsync(int mainPersonId, int connectedPersonId, CancellationToken cancellationToken);

    /// <summary>
    /// Get all connections list
    /// </summary>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>Person Connection model</returns>
    Task<IEnumerable<PersonConnection>> GetAllConnectionsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Delete all connections by person
    /// </summary>
    /// <param name="personId">person id</param>
    void DeleteAllConnectionsByPerson(int personId);
}

