using GitHub.Domain.Entities;

namespace GitHub.Data.IRepositories;
public interface IOrganizationProjectRepository
{
    public ValueTask<OrganizationProject> InsertAsync(OrganizationProject organizationProject);
    public ValueTask<OrganizationProject> UpdateAsync(OrganizationProject organizationProject);
    public ValueTask<bool> DeleteAsync(long id);
    public ValueTask<OrganizationProject> SelectAsync(long id);
    public ValueTask<IQueryable<OrganizationProject>> SelectAllAsync();
}
