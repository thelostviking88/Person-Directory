using AutoMapper;
using PersonDirectory.Application.Models;
using PersonDirectory.Domain.Models;

namespace PersonDirectory.Application.Mapping;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Person, PersonDto>();
        CreateMap<City, CityDto>();
        CreateMap<Phone, PhoneDto>();
        CreateMap<PersonConnection, ConnectionDto>();
        CreateMap<ConnectionRequestDto, PersonConnection>();
        CreateMap<Person, ConnectedPersonDto>();

        CreateMap<PersonPutDto, Person>();
        CreateMap<PersonPostDto, Person>();
        CreateMap<CityDto, City>();
        CreateMap<PhoneDto, Phone>();
    }
}