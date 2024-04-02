using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedDomain.Common;

namespace MedDomain.Entities;


[Table("organization")]
public class Organization : IEntity<int>
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("short_name")]
    [StringLength(100)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column("address")]
    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column("pinfl")]
    [StringLength(100)]
    public string Pinfl { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(100)]
    public string PhoneNumber { get; set; } = null!;

    [Column("oblast_id")]
    public int OblastId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("created_date")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey("OblastId")]
    [InverseProperty("Organizations")]
    public virtual Oblast Oblast { get; set; } = null!;

    [ForeignKey("RegionId")]
    [InverseProperty("Organizations")]
    public virtual Region Region { get; set; } = null!;

    [InverseProperty("Organization")]
    public virtual ICollection<UserModule> UserModules { get; set; } = new List<UserModule>();

    [InverseProperty("Organization")]
    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}