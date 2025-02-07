using PersonDirectory.Domain.Models;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// Phone Repository
/// </summary>
public interface IPhoneRepository
{
    /// <summary>
    /// Adds the asynchronous.
    /// </summary>
    /// <param name="phone">The phone.</param>
    /// <returns></returns>
    Task AddAsync(Phone phone);

    /// <summary>
    /// Deletes the many.
    /// </summary>
    /// <param name="phones">The phones.</param>
    void DeleteMany(IEnumerable<Phone> phones);
}
