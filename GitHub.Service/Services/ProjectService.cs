using AutoMapper;
using GitHub.Data.IRepositories;
using GitHub.Data.Repositories;
using GitHub.Domain.Entities;
using GitHub.Service.DTOs;
using GitHub.Service.Helpers;
using GitHub.Service.Interfaces;

namespace GitHub.Service.Services;
public class ProjectService : IProjectService
{
    private readonly IProjectRepository projectRepository = new ProjectRepository();
    private readonly IMapper mapper;
    public ProjectService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async ValueTask<Response<ProjectDto>> AddAsync(ProjectForCreationDto projectForCreationDto)
    {
        var mapped = this.mapper.Map<Project>(projectForCreationDto);
        var addedProject = await this.projectRepository.InsertAsync(mapped);
        var resultDto = this.mapper.Map<ProjectDto>(addedProject);
        return new Response<ProjectDto>
        {
            Code = 200,
            Message = "Success",
            Value = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var project = await this.projectRepository.DeleteAsync(id);
        if (project == false)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.projectRepository.DeleteAsync(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<ProjectDto>>> GetAllAsync()
    {
        var projects = await this.projectRepository.SelectAllAsync();
        var mappedUsers = this.mapper.Map<List<ProjectDto>>(projects);
        return new Response<List<ProjectDto>>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }

    public async ValueTask<Response<ProjectDto>> GetByIdAsync(long id)
    {
        Project project = await this.projectRepository.SelectAsync(id);
        if (project is null)
            return new Response<ProjectDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var mappedUsers = this.mapper.Map<ProjectDto>(project);
        return new Response<ProjectDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }

    public async ValueTask<Response<ProjectDto>> ModifyAsync(long id, ProjectForCreationDto userForCreationDto)
    {
        Project project = await this.projectRepository.SelectAsync(id);
        if (project is null)
            return new Response<ProjectDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var updatedProject = await this.projectRepository.UpdateAsync(project);
        var mappedProjects = this.mapper.Map<ProjectDto>(updatedProject);
        return new Response<ProjectDto>    
        {
            Code = 200,
            Message = "Success",
            Value = mappedProjects
        };
    }
}
