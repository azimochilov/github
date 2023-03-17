using GitHub.Domain.Enums;

namespace GitHub.Service.DTOs;
public class UserDto
{
    public string Name { get; set; }
    public string Username { get; set; }
    public UserRoleType Role { get; set; }
}
