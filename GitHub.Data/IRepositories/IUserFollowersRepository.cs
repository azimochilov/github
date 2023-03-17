using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IUserFollowersRepository
{
    public ValueTask<UserFollowers> InsertAsync(UserFollowers userFollowers);
    public ValueTask<UserFollowers> UpdateAsync(UserFollowers userFollowers);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<UserFollowers> SelectAsync(long id);
    public ValueTask<IQueryable<UserFollowers>> SelectAllAsync();
}
