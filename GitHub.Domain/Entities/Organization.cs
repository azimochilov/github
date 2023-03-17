using GitHub.Domain.Commons;
using GitHub.Domain.Enums;

namespace GitHub.Domain.Entities;
public class Organization : Auditable
{
    public string OrganizationName { get; set; }
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public PrivacyType Privacy { get; set; }    

}
