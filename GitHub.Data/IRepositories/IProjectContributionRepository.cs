using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IProjectContributionRepository
{
    public ValueTask<ProjectContribution> InsertAsync(ProjectContribution project);
    public ValueTask<ProjectContribution> UpdateAsync(ProjectContribution project);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<ProjectContribution> SelectAsync(long id);
    public ValueTask<IQueryable<ProjectContribution>> SelectAllAsync();
}
