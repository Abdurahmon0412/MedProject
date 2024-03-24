using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("payment")]
public class Payment : IEntity<int>
{
    public Payment()
    {
        Patients = new HashSet<Patient>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("details")]
    [StringLength(500)]
    public string Details { get; set; } = null!;
    [Column("plastic_card_id")]
    public int PlasticCardId { get; set; }
    [Column("payment_hystory")]
    public int PaymentHystory { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(PlasticCardId))]
    [InverseProperty("Payments")]
    public virtual PlasticCard PlasticCard { get; set; } = null!;
    [InverseProperty(nameof(Patient.Payment))]
    public virtual ICollection<Patient> Patients { get; set; }
}
