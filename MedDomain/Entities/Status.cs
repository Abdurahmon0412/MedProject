﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedDomain.Common;

namespace MedDomain.Entities;

[Table("status")]
public class Status : IEntity<int>
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

    [Column("details")]
    [StringLength(500)]
    public string? Details { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [InverseProperty("Status")]
    public virtual ICollection<UserModule> UserModules { get; set; } = new List<UserModule>();
}