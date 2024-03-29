﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedDomain.Common;
namespace MedDomain.Entities;

[Table("address")]
public class Address : IEntity<int>
{
    public Address()
    {
        Patients = new HashSet<Patient>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("short_name")]
    [StringLength(100)]
    public string ShortName { get; set; } = null!;
    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;
    [Column("oblast_id")]
    public int OblastId { get; set; }
    [Column("region_id")]
    public int RegionId { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(OblastId))]
    [InverseProperty("Addresses")]
    public virtual Oblast Oblast { get; set; }
    [ForeignKey(nameof(RegionId))]
    [InverseProperty("Addresses")]
    public virtual Region Region { get; set; } = null!;
    [InverseProperty(nameof(Patient.Address))]
    public virtual ICollection<Patient> Patients { get; set; }
}