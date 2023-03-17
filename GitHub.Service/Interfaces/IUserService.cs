using GitHub.Domain.Configurations;
using GitHub.Service.DTOs;
using GitHub.Service.Helpers;

namespace GitHub.Service.Interfaces;
public interface IUserService
{
    ValueTask<Response<UserDto>> AddAsync(UserForCreationDto userForCreationDto);
    ValueTask<Response<UserDto>> ModifyAsync(long id, UserForCreationDto userForCreationDto);
    ValueTask<Response<bool>> DeleteAsync(long id);
    ValueTask<Response<UserDto>> GetByIdAsync(long id);
    ValueTask<Response<List<UserDto>>> GetAllAsync();
}
