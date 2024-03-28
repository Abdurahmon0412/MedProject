using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("doctor")]
public class Doctor : IEntity<int>
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    [StringLength(100)]
    public string? FirstName { get; set; }
    [Column("last_name")]
    [StringLength(100)]
    public string? LastName { get; set; }
    [Column("doctor_info_id")]
    public int DoctorInfoId { get; set; }
    [Column("department_id")]
    public int DepartmentId { get; set; }
    [Column("user_module_id")]
    public long UserModuleId { get; set; }
    [Column("patient_count_by_day")]
    public int? PatientCountByDay { get; set; }
    [Column("doctor_place_id")]
    public int DoctorPlaceId { get; set; }
    [Column("patient_id")]
    public int? PatientId { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    [InverseProperty("Doctors")]
    public virtual Department Department { get; set; } = null!;
    [ForeignKey(nameof(DoctorInfoId))]
    [InverseProperty("Doctors")]
    public virtual DoctorInfo DoctorInfo { get; set; } = null!;
    [ForeignKey(nameof(DoctorPlaceId))]
    [InverseProperty("Doctors")]
    public virtual DoctorPlace DoctorPlace { get; set; } = null!;
    [ForeignKey(nameof(PatientId))]
    [InverseProperty("Doctors")]
    public virtual Patient? Patient { get; set; }

    [ForeignKey(nameof(UserModuleId))]
    [InverseProperty("Doctors")]
    public virtual UserModule UserModule { get; set; } = null!;
}
