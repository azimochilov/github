using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class OrganizationProjectRepository : IOrganizationProjectRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        OrganizationProject entity = await appDbContext.OrganizationProjects.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.OrganizationProjects.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<OrganizationProject> InsertAsync(OrganizationProject org)
    {
        EntityEntry<OrganizationProject> entityEntry = await appDbContext.OrganizationProjects.AddAsync(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<OrganizationProject>> SelectAllAsync()
    {
        return appDbContext.OrganizationProjects.Where(e => true);
    }

    public async ValueTask<OrganizationProject> SelectAsync(long id)
    {
        OrganizationProject entity = await appDbContext.OrganizationProjects.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<OrganizationProject> UpdateAsync(OrganizationProject org)
    {
        EntityEntry<OrganizationProject> entityEntry = appDbContext.OrganizationProjects.Update(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
