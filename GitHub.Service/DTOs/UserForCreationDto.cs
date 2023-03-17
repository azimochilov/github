using GitHub.Domain.Enums;

namespace GitHub.Service.DTOs;
public class UserForCreationDto
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRoleType Role { get; set; }
}
