using GitHub.Domain.Commons;

namespace GitHub.Domain.Entities;
public class OrganizationProject : Auditable
{
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long OrganizationId { get; set; }
    public Organization Organization { get; set; }  
}
