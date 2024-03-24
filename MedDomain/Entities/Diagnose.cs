using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("diagnose")]
public class Diagnose : IEntity<int>
{
    public Diagnose()
    {
        Patients = new HashSet<Patient>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("short_name")]
    [StringLength(100)]
    public string? ShortName { get; set; }
    [Column("full_name")]
    [StringLength(100)]
    public string? FullName { get; set; }
    [Column("medicine_id")]
    public int MedicineId { get; set; }
    [Column("details")]
    [StringLength(100)]
    public string? Details { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(MedicineId))]
    [InverseProperty("Diagnoses")]
    public virtual Medicine Medicine { get; set; } = null!;
    [InverseProperty(nameof(Patient.Diagnose))]
    public virtual ICollection<Patient> Patients { get; set; }
}
