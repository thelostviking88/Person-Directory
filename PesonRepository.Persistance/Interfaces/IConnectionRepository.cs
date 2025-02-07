using PersonDirectory.Domain.Models;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Interfaces;

public interface IConnectionRepository 
{
    void CreateConnection(PersonConnection personConnection);
    void DeleteConnection(PersonConnection personConnection);
    Task<PersonConnection> GetConnectionByConnectedPersonId(int ConnectedPersonId);
}
