using GitHub.Domain.Entities;
using GitHub.Domain.Enums;

namespace GitHub.Service.DTOs;
public class ProjectDto
{
    public string ProjectName { get; set; }
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public PrivacyType Privacy { get; set; }
    public ProgrammingLanType ProgrammingLanguage { get; set; }
}
