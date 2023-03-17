using GitHub.Domain.Commons;
using GitHub.Domain.Enums;

namespace GitHub.Domain.Entities;
public class User : Auditable
{
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public UserRoleType Role { get; set; }
}
