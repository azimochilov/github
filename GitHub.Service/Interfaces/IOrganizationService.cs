using GitHub.Service.DTOs;
using GitHub.Service.Helpers;

namespace GitHub.Service.Interfaces;
public interface IOrganizationService
{
    ValueTask<Response<OrganizationDto>> AddAsync(OrganizationForCreationDto organizationForCreationDto);
    ValueTask<Response<OrganizationDto>> ModifyAsync(long id, OrganizationForCreationDto organizationForCreationDto);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<OrganizationDto>> GetByIdAsync(long id);
    ValueTask<Response<List<OrganizationDto>>> GetAllAsync();
}
