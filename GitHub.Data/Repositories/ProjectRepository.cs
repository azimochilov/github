using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class ProjectRepository : IProjectRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        Project entity = await appDbContext.Projects.FirstOrDefaultAsync(pr => pr.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Projects.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Project> InsertAsync(Project project)
    {
        EntityEntry<Project> entityEntry = await appDbContext.Projects.AddAsync(project);
        await appDbContext.SaveChangesAsync();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<Project>> SelectAllAsync()
    {
        return appDbContext.Projects.Where(e => true);
    }

    public async ValueTask<Project> SelectAsync(long id)
    {
        Project entity = await appDbContext.Projects.FirstOrDefaultAsync(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<Project> UpdateAsync(Project project)
    {
        EntityEntry<Project> entityEntry = appDbContext.Projects.Update(project);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
