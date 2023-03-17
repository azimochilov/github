using GitHub.Domain.Commons;
using GitHub.Domain.Enums;

namespace GitHub.Domain.Entities;
public class Project : Auditable
{
    public string ProjectName { get; set; }
    public long AuthorId { get; set; }
    public User Author { get; set; }
    public PrivacyType Privacy { get; set; }
    public ProgrammingLanType ProgrammingLanguage { get; set; }
}
