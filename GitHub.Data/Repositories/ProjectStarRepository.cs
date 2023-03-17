using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class ProjectStarRepository : IProjectStarRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        ProjectStar entity = await appDbContext.ProjectStars.FirstOrDefaultAsync(pr => pr.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.ProjectStars.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<ProjectStar> InsertAsync(ProjectStar project)
    {
        EntityEntry<ProjectStar> entityEntry = await appDbContext.ProjectStars.AddAsync(project);
        await appDbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<ProjectStar>> SelectAllAsync()
    {
        return appDbContext.ProjectStars.Where(e => true);
    }

    public async ValueTask<ProjectStar> SelectAsync(long id)
    {
        ProjectStar entity = await appDbContext.ProjectStars.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<ProjectStar> UpdateAsync(ProjectStar project)
    {
        EntityEntry<ProjectStar> entityEntry = appDbContext.ProjectStars.Update(project);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
