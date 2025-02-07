using PersonDirectory.Application.Interfaces;
using PersonDirectory.Domain.Models;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Repositories
{
    public class UnitOfWork(PersonDbContext context,
                      IPersonRepository personRepository,
                      IPhoneRepository phoneRepository,
                      IConnectionRepository connectionRepository,
                      ICityRepository cityRepository) : IUnitOfWork
    {
        private readonly PersonDbContext _context = context;

        // Repositories for each entity
        public IPersonRepository PersonRepository { get; } = personRepository;
        public IPhoneRepository PhoneRepository { get; } = phoneRepository;
        public IConnectionRepository ConnectionRepository { get; } = connectionRepository;
        public ICityRepository CityRepository { get; } = cityRepository;

        // This method will save all changes to the database
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Dispose method to release resources
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
