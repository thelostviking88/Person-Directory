using PersonDirectory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using PersonDirectory.Application.Interfaces;
using System.Threading;
using System.Collections.Generic;


namespace PersonDirectory.Persistance.Repositories;

public class ConnectionRepository(PersonDbContext context) : IConnectionRepository
{
    private readonly PersonDbContext _dbContext = context;

    public async Task CreateConnectionAsync(PersonConnection personConnection, CancellationToken cancellationToken)
    {
        await _dbContext.PersonConnections.AddAsync(personConnection,cancellationToken);
    }

    public void DeleteConnection(PersonConnection personConnection)
    {
        _dbContext.PersonConnections.Remove(personConnection);
    }

    public async Task<PersonConnection> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _dbContext.PersonConnections.FindAsync(id,cancellationToken);
    }

    public async Task<PersonConnection> GetConnectionAsync(int mainPersonId, int connectedPersonId, CancellationToken cancellationToken)
    {
        return await _dbContext.PersonConnections.Where(c => (c.ConnectedPersonId == connectedPersonId) && (c.PersonId == mainPersonId)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<PersonConnection>> GetAllConnectionsAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.PersonConnections.Include(i=>i.MainPerson).ToListAsync(cancellationToken);
    }

    public void DeleteAllConnectionsByPerson(int personId) 
    {
        var connections = _dbContext.PersonConnections.Where(w => w.ConnectedPersonId == personId || w.PersonId == personId);
        _dbContext.PersonConnections.RemoveRange(connections);
    }
}
