using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("examination")]
public class Examination : IEntity<int>
{
    public Examination()
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
    [Column("details")]
    [StringLength(100)]
    public string? Details { get; set; }
    [Column("number")]
    public int? Number { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [InverseProperty(nameof(Patient.Examination))]
    public virtual ICollection<Patient> Patients { get; set; }
}
