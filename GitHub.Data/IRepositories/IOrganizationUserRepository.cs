using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IOrganizationUserRepository
{
    public ValueTask<OrganizationUser> InsertAsync(OrganizationUser organizationUser);
    public ValueTask<OrganizationUser> UpdateAsync(OrganizationUser organizationUser);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<OrganizationUser> SelectAsync(long id);
    public ValueTask<IQueryable<OrganizationUser>> SelectAllAsync();
}
