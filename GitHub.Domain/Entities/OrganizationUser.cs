using GitHub.Domain.Commons;

namespace GitHub.Domain.Entities;
public class OrganizationUser : Auditable
{
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
