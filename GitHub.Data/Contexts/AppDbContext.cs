using GitHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GitHub.Data.Contexts;
public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        string path = "Server = (localdb)\\MSSQLLocalDB;" +
            "Database = GitHub;" +
            "Trusted_Connection = True";
        optionBuilder.UseSqlServer(path);
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectStar> ProjectStars { get; set;}
    public DbSet<UserFollowers> UserFollowers { get; set; }
    public DbSet<ProjectContribution> ProjectContributions { get; set; }
    public DbSet<OrganizationUser> OrganizationUsers { get; set;}
    public DbSet<OrganizationProject> OrganizationProjects { get; set;}
}
