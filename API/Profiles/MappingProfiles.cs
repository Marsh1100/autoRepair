using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Person,PersonDto>().ReverseMap();
        CreateMap<Customer,CustomerDto>().ReverseMap();

    }
}
