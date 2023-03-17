using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IProjectStarRepository
{
    public ValueTask<ProjectStar> InsertAsync(ProjectStar project);
    public ValueTask<ProjectStar> UpdateAsync(ProjectStar project);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<ProjectStar> SelectAsync(long id);
    public ValueTask<IQueryable<ProjectStar>> SelectAllAsync();
}
