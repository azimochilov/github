using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class ProjectContributionRepository : IProjectContributionRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        ProjectContribution entity = await appDbContext.ProjectContributions.FirstOrDefaultAsync(pr => pr.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.ProjectContributions.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<ProjectContribution> InsertAsync(ProjectContribution project)
    {
        EntityEntry<ProjectContribution> entityEntry = await appDbContext.ProjectContributions.AddAsync(project);
        await appDbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<ProjectContribution>> SelectAllAsync()
    {
        return appDbContext.ProjectContributions.Where(e => true);
    }

    public async ValueTask<ProjectContribution> SelectAsync(long id)
    {
        ProjectContribution entity = await appDbContext.ProjectContributions.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<ProjectContribution> UpdateAsync(ProjectContribution project)
    {
        EntityEntry<ProjectContribution> entityEntry = appDbContext.ProjectContributions.Update(project);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
