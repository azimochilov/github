using GitHub.Domain.Enums;

namespace GitHub.Service.DTOs;
public class OrganizationForCreationDto
{
    public string OrganizationName { get; set; }
    public PrivacyType Privacy { get; set; }
    public long AuthorId { get; set; }
}
