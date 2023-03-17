using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class OrganizationUserRepository : IOrganizationUserRepository
{

    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        OrganizationUser entity = await appDbContext.OrganizationUsers.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.OrganizationUsers.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }

    public async ValueTask<OrganizationUser> InsertAsync(OrganizationUser org)
    {
        EntityEntry<OrganizationUser> entityEntry = await appDbContext.OrganizationUsers.AddAsync(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<OrganizationUser>> SelectAllAsync()
    {
        return appDbContext.OrganizationUsers.Where(e => true);
    }

    public async ValueTask<OrganizationUser> SelectAsync(long id)
    {
        OrganizationUser entity = await appDbContext.OrganizationUsers.FirstOrDefaultAsync(org => org.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<OrganizationUser> UpdateAsync(OrganizationUser org)
    {
        EntityEntry<OrganizationUser> entityEntry = appDbContext.OrganizationUsers.Update(org);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
