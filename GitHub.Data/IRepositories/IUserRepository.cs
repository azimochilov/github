using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IUserRepository
{
    public ValueTask<User> InsertAsync(User user);
    public ValueTask<User> UpdateAsync(User user);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<User> SelectAsync(long id);
    public ValueTask<IQueryable<User>> SelectAllAsync();

}
