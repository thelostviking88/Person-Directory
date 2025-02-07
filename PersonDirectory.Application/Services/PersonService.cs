using PersonDirectory.Application.Models;
using AutoMapper;
using PersonDirectory.Domain.Models;
using PersonDirectory.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using PersonDirectory.Application.Resources;
using Microsoft.EntityFrameworkCore;
using PersonDirectory.Application.Extensions;

namespace PersonDirectory.Application.Services;

/// </inheritdoc>
public partial class PersonService(IUnitOfWork uow, IMapper mapper, IStringLocalizer<SharedValidatorResources> localizer, IFileService fileService) : IPersonService
{
    private readonly IUnitOfWork _unitOfWork = uow;
    private readonly IMapper _mapper = mapper;
    private readonly IStringLocalizer<SharedValidatorResources> _localizer = localizer;
    private readonly IFileService _fileService = fileService;


    /// </inheritdoc>
    public async Task<PersonDto> GetById(int id, CancellationToken cancellationToken)
    {

        return _mapper.Map<PersonDto>(await _unitOfWork.PersonRepository.GetPersonWithDetailsAsync(id, cancellationToken));
    }

    /// </inheritdoc>
    public async Task Update(int id, PersonPutDto person, CancellationToken cancellationToken)
    {
        await EnsurePersonIsFound(id, _localizer["Notfound"], cancellationToken);

        await EnsureCityIsFound(person.CityId, _localizer["CityNotfound"], cancellationToken);

        var personEntity = _mapper.Map<Person>(person);
        personEntity.Id = id;

        _unitOfWork.PersonRepository.Update(personEntity);

        await _unitOfWork.CommitAsync();
    }

    /// </inheritdoc>
    public async Task<PersonDto> Create(PersonPostDto person, CancellationToken cancellationToken)
    {
        await EnsureCityIsFound(person.CityId, _localizer["CityNotfound"], cancellationToken);

        var personEntity = _mapper.Map<PersonPostDto, Person>(person);
        await _unitOfWork.PersonRepository.CreateAsync(personEntity, cancellationToken);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<Person, PersonDto>(personEntity);
    }


    /// </inheritdoc>
    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var personEntity = await _unitOfWork.PersonRepository.GetAsync(id, cancellationToken);
        if (personEntity == null)
        {
            return false;
        }
        _unitOfWork.ConnectionRepository.DeleteAllConnectionsByPerson(personEntity.Id);
        _unitOfWork.PhoneRepository.DeleteMany(personEntity.Phones);
        _unitOfWork.PersonRepository.Delete(personEntity);
        await _unitOfWork.CommitAsync();
        return true;
    }

    /// </inheritdoc>
    public async Task<PersonDto> UpdateImageAsync(int personId, string imageUrl, CancellationToken cancellationToken)
    {
        try
        {
            var personEntity = await _unitOfWork.PersonRepository.GetByIdAsync(personId, cancellationToken) ?? throw new KeyNotFoundException(_localizer["Notfound"]);

            var ImageOld = personEntity.Picture;
            personEntity.Picture = imageUrl;
            _unitOfWork.PersonRepository.Update(personEntity);
            await _unitOfWork.CommitAsync();

            if (!string.IsNullOrWhiteSpace(ImageOld))
            {
                await _fileService.DeleteFileAsync(ImageOld, cancellationToken);

            }
            return _mapper.Map<Person, PersonDto>(personEntity);
        }
        catch
        {
            throw;
        }
    }

    public async Task<IEnumerable<PersonDto>> Search(string searchString, CancellationToken cancellationToken)
    {
        var repResult = await _unitOfWork.PersonRepository
            .GetByCondition(
            w => w.PrivateNumber.Contains(searchString) ||
            w.LastName.Contains(searchString) ||
            w.FirstName.Contains(searchString),
            cancellationToken);

        return _mapper.Map<IEnumerable<PersonDto>>(repResult);
    }
    /// </inheritdoc>
    public async Task<PagedResponseDto<PersonDto>> DetailedSearchAsync(
         PaginationParams paginationParams,
         PersonSearchRequestDto searchRequest)
    {
        var query = _unitOfWork.PersonRepository.DetailedSearch(searchRequest).AsQueryable();

        var totalRecords = await query.CountAsync();
        var persons = await query
            .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
        .ToListAsync();

        return new PagedResponseDto<PersonDto>(_mapper.Map<IEnumerable<PersonDto>>(persons), paginationParams.PageNumber, paginationParams.PageSize, totalRecords);
    }

    /// </inheritdoc>
    public async Task<ConnectionDto> CreateConnectionAsync(ConnectionRequestDto connectionDto, CancellationToken cancellationToken)
    {
        // check that connection persons both exist 

        await EnsurePersonIsFound(connectionDto.PersonId, _localizer["PersonNotfound"], cancellationToken);
        await EnsurePersonIsFound(connectionDto.ConnectedPersonId, _localizer["ConnectedPersonNotfound"], cancellationToken);

        // check that connection doesnt already exist
        await EnsureConnectionNotExists(connectionDto.PersonId, connectionDto.ConnectedPersonId, _localizer["ConnectedPersonAlreadyExists"], cancellationToken);

        var connectionEntity = _mapper.Map<PersonConnection>(connectionDto);

        await _unitOfWork.ConnectionRepository.CreateConnectionAsync(connectionEntity, cancellationToken);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<ConnectionDto>(connectionEntity);
    }

    /// </inheritdoc>
    public async Task<bool> RemoveConnection(int id, CancellationToken cancellationToken)
    {
        var connectionEntity = await _unitOfWork.ConnectionRepository.GetByIdAsync(id, cancellationToken);
        if (connectionEntity == null)
        {
            return false;
        }

        _unitOfWork.ConnectionRepository.DeleteConnection(connectionEntity);
        await _unitOfWork.CommitAsync();

        return true;
    }

    /// </inheritdoc>
    public async Task<Dictionary<int, PersonConnectionsReportDto>> GetPersonConnectionsTypeCounts(CancellationToken cancellationToken)
    {
        var connectionCountsByPerson = new Dictionary<int, PersonConnectionsReportDto>();

        var connections = await _unitOfWork.ConnectionRepository.GetAllConnectionsAsync(cancellationToken);

        var personGroups = connections
            .GroupBy(pc => pc.PersonId)
            .Select(group => new
            {
                PersonDetails = group.FirstOrDefault()?.MainPerson,
                PersonId = group.Key,
                ConnectionsByType = group
                    .GroupBy(pc => pc.ConnectionType)
                    .Select(typeGroup => new
                    {
                        ConnectionType = typeGroup.Key,
                        Count = typeGroup.Count()
                    })
                    .ToList()
            })
            .ToList();

        foreach (var personGroup in personGroups)
        {
            var connectionsByType = personGroup.ConnectionsByType.ToDictionary(x => x.ConnectionType.ToLocalizedString(_localizer), x => x.Count);

            var report = new PersonConnectionsReportDto
            {
                FirstName = personGroup.PersonDetails?.FirstName!,
                LastName = personGroup.PersonDetails?.LastName!,
                PrivateNumber = personGroup.PersonDetails?.PrivateNumber!,
                ConnectionCounts = connectionsByType
            };

            connectionCountsByPerson.Add(personGroup.PersonId, report);
        }
       
        return connectionCountsByPerson;
    }
}