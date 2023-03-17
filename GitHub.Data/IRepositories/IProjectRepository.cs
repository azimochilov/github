using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IProjectRepository
{
    public ValueTask<Project> InsertAsync(Project project);
    public ValueTask<Project> UpdateAsync(Project project);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Project> SelectAsync(long id);
    public ValueTask<IQueryable<Project>> SelectAllAsync();
}
