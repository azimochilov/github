using AutoMapper;
using GitHub.Data.IRepositories;
using GitHub.Data.Repositories;
using GitHub.Domain.Configurations;
using GitHub.Domain.Entities;
using GitHub.Service.DTOs;
using GitHub.Service.Helpers;
using GitHub.Service.Interfaces;
namespace GitHub.Service.Services;
public class UserService : IUserService
{
    private readonly IUserRepository userRepository = new UserRepository();
    private readonly IMapper mapper;
    public UserService(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public async ValueTask<Response<UserDto>> AddAsync(UserForCreationDto userForCreationDto)
    {        
        var mappedUser = this.mapper.Map<User>(userForCreationDto);        
        var addedUser = await this.userRepository.InsertAsync(mappedUser);
        var resultDto = this.mapper.Map<UserDto>(addedUser);
        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = resultDto
        };
    }

    public async ValueTask<Response<bool>> DeleteAsync(long id)
    {
        var user = await this.userRepository.DeleteAsync(id);
        if (user == false)
            return new Response<bool>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = false
            };

        await this.userRepository.DeleteAsync(id);
        return new Response<bool>
        {
            Code = 200,
            Message = "Success",
            Value = true
        };
    }

    public async ValueTask<Response<List<UserDto>>> GetAllAsync()
    {
        var users = await this.userRepository.SelectAllAsync();               
        var mappedUsers = this.mapper.Map<List<UserDto>>(users);
        return new Response<List<UserDto>>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }

    public async ValueTask<Response<UserDto>> GetByIdAsync(long id)
    {
        User user = await this.userRepository.SelectAsync(id);
        if (user is null)
            return new Response<UserDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var mappedUsers = this.mapper.Map<UserDto>(user);
        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }

    public async ValueTask<Response<UserDto>> ModifyAsync(long id, UserForCreationDto userForCreationDto)
    {
        User user = await this.userRepository.SelectAsync(id);
        if (user is null)
            return new Response<UserDto>
            {
                Code = 404,
                Message = "Couldn't find for given ID",
                Value = null
            };

        var updatedUser = await this.userRepository.UpdateAsync(user);
        var mappedUsers = this.mapper.Map<UserDto>(updatedUser);
        return new Response<UserDto>
        {
            Code = 200,
            Message = "Success",
            Value = mappedUsers
        };
    }
}
