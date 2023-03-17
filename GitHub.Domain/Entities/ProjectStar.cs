using GitHub.Domain.Commons;

namespace GitHub.Domain.Entities;
public class ProjectStar : Auditable
{
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long UserId { get; set;}
    public User User { get; set; }
}
