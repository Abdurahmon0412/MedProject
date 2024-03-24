﻿using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("medicine")]
public class Medicine : IEntity<int>
{
    public Medicine()
    {
        Diagnoses = new HashSet<Diagnose>();
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
    [Column("is_consume")]
    public bool IsConsume { get; set; }
    [Column("how_many_times_day")]
    public int? HowManyTimesDay { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [InverseProperty(nameof(Diagnose.Medicine))]
    public virtual ICollection<Diagnose> Diagnoses { get; set; }
}
