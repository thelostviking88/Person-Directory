using PersonDirectory.Domain.Models;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Interfaces;

public interface IPhoneRepository
{
    Task AddAsync(Phone phone);
}
