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
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Diagnose> Diagnoses { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<DoctorInfo> DoctorInfos { get; set; }
    public virtual DbSet<DoctorPlace> DoctorPlaces { get; set; }
    public virtual DbSet<Examination> Examinations { get; set; }
    public virtual DbSet<Medicine> Medicines { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<PaymentHystory> PaymentHystories { get; set; }
    public virtual DbSet<PlasticCard> PlasticCards { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<WeekDay> WeekDays { get; set; }
    public virtual DbSet<WorkingHour> WorkingHours { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

    }
}