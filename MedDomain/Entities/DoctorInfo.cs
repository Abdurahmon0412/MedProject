using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("doctor_info")]
public class DoctorInfo : IEntity<int>
{
    public DoctorInfo()
    {
        Doctors = new HashSet<Doctor>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("details")]
    [StringLength(500)]
    public string? Details { get; set; }
    [Column("doctor_place_id")]
    public int DoctorPlaceId { get; set; }
    [Column("working_hours_id")]
    public int WorkingHoursId { get; set; }
    [Column("experiense_of_year")]
    public int? ExperienseOfYear { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(DoctorPlaceId))]
    [InverseProperty("DoctorInfos")]
    public virtual DoctorPlace DoctorPlace { get; set; } = null!;
    [ForeignKey(nameof(WorkingHoursId))]
    [InverseProperty(nameof(WorkingHour.DoctorInfos))]
    public virtual WorkingHour WorkingHours { get; set; } = null!;
    [InverseProperty(nameof(Doctor.DoctorInfo))]
    public virtual ICollection<Doctor> Doctors { get; set; }
}
