using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IOrganizationRepository
{
    public ValueTask<Organization> InsertAsync(Organization organization);
    public ValueTask<Organization> UpdateAsync(Organization organization);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<Organization> SelectAsync(long id);
    public ValueTask<IQueryable<Organization>> SelectAllAsync();
}