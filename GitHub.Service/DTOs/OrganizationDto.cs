using GitHub.Domain.Enums;

namespace GitHub.Service.DTOs;
public class OrganizationDto
{
    public string OrganizationName { get; set; }
    public PrivacyType Privacy { get; set; }
    public long AuthorId { get; set; }
}
