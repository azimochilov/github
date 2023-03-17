using AutoMapper;
using GitHub.Data.IRepositories;
using GitHub.Data.Repositories;
using GitHub.Domain.Entities;
using GitHub.Service.DTOs;
using GitHub.Service.Helpers;
using GitHub.Service.Interfaces;

namespace GitHub.Service.Services;
public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository organizationRepository = new OrganizationRepository();
    private readonly IMapper mapper;
    public OrganizationService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async ValueTask<Response<OrganizationDto>> AddAsync(OrganizationForCreationDto organizationForCreationDto)
    {
        var mapped = this.mapper.Map<Organization>(organizationForCreationDto);
        var addedOrg = await this.organizationRepository.InsertAsync(mapped);
        var resultDto = this.mapper.Map<OrganizationDto>(addedOrg);
        return new Response<OrganizationDto>
        {
            Code = 200,
            Message = "Success",
            Value = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var org = await this.organizationRepository.DeleteAsync(id);
        if (org == false)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.organizationRepository.DeleteAsync(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<OrganizationDto>>> GetAllAsync()
    {
        var org = await this.organizationRepository.SelectAllAsync();
        var mappedOrg = this.mapper.Map<List<OrganizationDto>>(org);
        return new Response<List<OrganizationDto>>
        {
            Code = 200,
            Message = "Success",
            Value = mappedOrg
        };
    }

    public async ValueTask<Response<OrganizationDto>> GetByIdAsync(long id)
    {
        Organization org = await this.organizationRepository.SelectAsync(id);
        if (org is null)
            return new Response<OrganizationDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var mappedOrg = this.mapper.Map<OrganizationDto>(org);
        return new Response<OrganizationDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedOrg
        };
    }

    public async ValueTask<Response<OrganizationDto>> ModifyAsync(long id, OrganizationForCreationDto userForCreationDto)
    {
        Organization org = await this.organizationRepository.SelectAsync(id);
        if (org is null)
            return new Response<OrganizationDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var updatedOrg = await this.organizationRepository.UpdateAsync(org);
        var mappedOrg = this.mapper.Map<OrganizationDto>(updatedOrg);
        return new Response<OrganizationDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedOrg
        };
    }
}
