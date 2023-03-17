using GitHub.Service.DTOs;
using GitHub.Service.Helpers;

namespace GitHub.Service.Interfaces;
public interface IProjectService
{
    ValueTask<Response<ProjectDto>> AddAsync(ProjectForCreationDto projectForCreationDto);
    ValueTask<Response<ProjectDto>> ModifyAsync(long id, ProjectForCreationDto projectForCreationDto);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<ProjectDto>> GetByIdAsync(long id);
    ValueTask<Response<List<ProjectDto>>> GetAllAsync();
}
