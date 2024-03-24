using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("doctor_place")]
public class DoctorPlace : IEntity<int>
{
    public DoctorPlace()
    {
        DoctorInfos = new HashSet<DoctorInfo>();
        Doctors = new HashSet<Doctor>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("floor")]
    public int? Floor { get; set; }
    [Column("room_number")]
    public int? RoomNumber { get; set; }
    [Column("room_name")]
    [StringLength(100)]
    public string RoomName { get; set; } = null!;
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [InverseProperty(nameof(DoctorInfo.DoctorPlace))]
    public virtual ICollection<DoctorInfo> DoctorInfos { get; set; }
    [InverseProperty(nameof(Doctor.DoctorPlace))]
    public virtual ICollection<Doctor> Doctors { get; set; }
}
