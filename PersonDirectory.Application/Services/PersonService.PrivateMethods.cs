using PersonDirectory.Domain.Models;
using PersonDirectory.Application.Interfaces;

namespace PersonDirectory.Application.Services;

/// </inheritdoc>
public partial class PersonService : IPersonService
{
    private async Task<Person> EnsurePersonIsFound(int id, string message, CancellationToken cancellationToken) 
    {
        var personEntity = await _unitOfWork.PersonRepository.GetByIdAsync(id, cancellationToken);
        if (personEntity == null)
        {
            throw new KeyNotFoundException(message);
        }

        return personEntity!;
    }

    private async Task<City> EnsureCityIsFound(int id, string message, CancellationToken cancellationToken)
    {
        var cityEntity = await _unitOfWork.CityRepository.GetByIdAsync(id, cancellationToken);
        if (cityEntity == null)
        {
            throw new KeyNotFoundException(message);
        }

        return cityEntity!;
    }

    private async Task<PersonConnection> EnsureConnectionExists(int personId,int connectedPersonId, string message, CancellationToken cancellationToken)
    {
        var connectionEntity = await _unitOfWork.ConnectionRepository.GetConnectionAsync(personId,connectedPersonId, cancellationToken);
        if (connectionEntity == null)
        {
            throw new KeyNotFoundException(message);
        }

        return connectionEntity!;
    }
    private async Task<PersonConnection> EnsureConnectionNotExists(int personId,int connectedPersonId, string message, CancellationToken cancellationToken)
    {
        var connectionEntity = await _unitOfWork.ConnectionRepository.GetConnectionAsync(personId,connectedPersonId, cancellationToken);
        if (connectionEntity != null)
        {
            throw new KeyNotFoundException(message);
        }

        return connectionEntity!;
    }
}