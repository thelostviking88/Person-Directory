using PersonDirectory.Domain.Models;
using System.Threading.Tasks;
using PersonDirectory.Application.Interfaces;
using System.Threading;


namespace PersonDirectory.Persistance.Repositories;

public class CityRepository(PersonDbContext context) : ICityRepository
{
    private readonly PersonDbContext _dbContext = context;

    public async Task<City> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.Cities.FindAsync(id, cancellationToken);
    }
}