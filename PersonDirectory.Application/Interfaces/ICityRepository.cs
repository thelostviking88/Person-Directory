using PersonDirectory.Domain.Models;

namespace PersonDirectory.Application.Interfaces;

/// <summary>
/// City repository
/// </summary>
public interface ICityRepository 
{
    /// <summary>
    /// Get by id
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">cancellation token</param>
    /// <returns>city model</returns>
    Task<City> GetByIdAsync(int id, CancellationToken cancellationToken);    
}
