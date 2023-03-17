using GitHub.Data.Contexts;
using GitHub.Data.IRepositories;
using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GitHub.Data.Repositories;
public class UserRepository : IUserRepository
{
    private readonly AppDbContext appDbContext = new AppDbContext();
    public async ValueTask<bool> DeleteAsync(long id)
    {
        User entity = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        if (entity == null)
        {
            return false;
        }
        appDbContext.Users.Remove(entity);
        await appDbContext.SaveChangesAsync();
        return true;        
    }

    public async ValueTask<User> InsertAsync(User user)
    {
        EntityEntry<User> entityEntry = await appDbContext.Users.AddAsync(user);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }

    public async ValueTask<IQueryable<User>> SelectAllAsync()
    {
        return appDbContext.Users.Where(e => true);
    }

    public async ValueTask<User> SelectAsync(long id)
    {
        User entity = appDbContext.Users.FirstOrDefault(u => u.Id == id);
        if (entity == null)
        {
            return null;
        }
        return entity;        
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        EntityEntry<User> entityEntry = appDbContext.Users.Update(user);
        appDbContext.SaveChanges();
        return entityEntry.Entity;
    }
}
