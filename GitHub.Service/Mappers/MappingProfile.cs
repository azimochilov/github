using AutoMapper;
using GitHub.Domain.Entities;
using GitHub.Service.DTOs;

namespace GitHub.Service.Mappers;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
    CreateMap<UserForCreationDto, User>().ReverseMap();
    CreateMap<UserDto, User>().ReverseMap();
    CreateMap<ProjectForCreationDto, Project>().ReverseMap();
    CreateMap<ProjectDto, Project>().ReverseMap();
    CreateMap<OrganizationForCreationDto, Organization>().ReverseMap();
    CreateMap<OrganizationForCreationDto, Organization>().ReverseMap();

    }
}
