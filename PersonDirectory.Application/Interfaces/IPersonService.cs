using PersonDirectory.Application.Models;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// Person Service
/// </summary>
public interface IPersonService
{
    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Person model</returns>
    Task<PersonDto> GetById(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates the specified person.
    /// </summary>
    /// <param name="person">The person.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Person model</returns>
    Task<PersonDto> Create(PersonPostDto person, CancellationToken cancellationToken);

    /// <summary>
    /// Updates the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="person">The person.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Person model</returns>
    Task Update(int id, PersonPutDto person, CancellationToken cancellationToken);

    /// <summary>
    /// Searches the specified search string.
    /// </summary>
    /// <param name="searchString">The search string.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>List of Persons</returns>
    Task<IEnumerable<PersonDto>> Search(string searchString, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>bool</returns>
    Task<bool> Delete(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the person connections type counts.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns> Connections dictionary</returns>
    Task<Dictionary<int, PersonConnectionsReportDto>> GetPersonConnectionsTypeCounts(CancellationToken cancellationToken);

    /// <summary>
    /// Updates the image.
    /// </summary>
    /// <param name="personId">The person identifier.</param>
    /// <param name="Url">The URL.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns> Person model</returns>
    Task<PersonDto> UpdateImageAsync(int personId, string Url, CancellationToken cancellationToken);

    /// <summary>
    /// Creates the connection.
    /// </summary>
    /// <param name="connectionDto">The connection dto.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>Connection Model</returns>
    Task<ConnectionDto> CreateConnectionAsync(ConnectionRequestDto connectionDto, CancellationToken cancellationToken);

    /// <summary>
    /// Removes the connection.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>bool</returns>
    Task<bool> RemoveConnection(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Detailed search asynchronous.
    /// </summary>
    /// <param name="paginationParams">The pagination parameters.</param>
    /// <param name="searchRequest">The search request.</param>
    /// <returns>Person model</returns>
    Task<PagedResponseDto<PersonDto>> DetailedSearchAsync(PaginationParams paginationParams, PersonSearchRequestDto searchRequest);
}

