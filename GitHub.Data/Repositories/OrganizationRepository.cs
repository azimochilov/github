using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class OrganizationRepository : IOrganizationRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        Organization entity = await appDbContext.Organizations.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Organizations.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<Organization> InsertAsync(Organization org)
    {
        EntityEntry<Organization> entityEntry = await appDbContext.Organizations.AddAsync(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<Organization>> SelectAllAsync()
    {
        return appDbContext.Organizations.Where(e => true);
    }

    public async ValueTask<Organization> SelectAsync(long id)
    {
        Organization entity = await appDbContext.Organizations.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<Organization> UpdateAsync(Organization org)
    {
        EntityEntry<Organization> entityEntry = appDbContext.Organizations.Update(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
