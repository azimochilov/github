using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class UserFollowersRepository : IUserFollowersRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        UserFollowers entity = await appDbContext.UserFollowers.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.UserFollowers.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;
    }
    public async ValueTask<UserFollowers> InsertAsync(UserFollowers user)
    {
        EntityEntry<UserFollowers> entityEntry = await appDbContext.UserFollowers.AddAsync(user);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<UserFollowers>> SelectAllAsync()
    {
        return appDbContext.UserFollowers.Where(e => true);
    }

    public async ValueTask<UserFollowers> SelectAsync(long id)
    {
        UserFollowers entity = appDbContext.UserFollowers.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;
    }

    public async ValueTask<UserFollowers> UpdateAsync(UserFollowers user)
    {
        EntityEntry<UserFollowers> entityEntry = appDbContext.UserFollowers.Update(user);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
