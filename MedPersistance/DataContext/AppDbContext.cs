using MedDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedPersistance.DataContext;

public partial class MContext : DbContext
{
    public MContext()
    {
    }

    public MContext(DbContextOptions<MContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }
    public virtual DbSet<Role> Languages { get; set; }
    public virtual DbSet<Oblast> Oblasts { get; set; }
    public virtual DbSet<Organization> Organizations { get; set; }
    public virtual DbSet<Region> Regions { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Roletype> RoleTypes { get; set; }
    public virtual DbSet<Status> Statuses { get; set; }
    public virtual DbSet<UserModule> UserModules { get; set; }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}