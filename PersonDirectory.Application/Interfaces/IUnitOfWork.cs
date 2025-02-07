namespace PersonDirectory.Application.Interfaces;
/// <summary>
/// Unit of work Interface
/// </summary>
/// <seealso cref="System.IDisposable" />
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets the person repository.
    /// </summary>
    /// <value>
    /// The person repository.
    /// </value>
    IPersonRepository PersonRepository { get; }
    /// <summary>
    /// Gets the phone repository.
    /// </summary>
    /// <value>
    /// The phone repository.
    /// </value>
    IPhoneRepository PhoneRepository { get; }
    /// <summary>
    /// Gets the connection repository.
    /// </summary>
    /// <value>
    /// The connection repository.
    /// </value>
    IConnectionRepository ConnectionRepository { get; }
    /// <summary>
    /// Gets the city repository.
    /// </summary>
    /// <value>
    /// The city repository.
    /// </value>
    ICityRepository CityRepository { get; }
    /// <summary>
    /// Commits the asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<int> CommitAsync();
}
