﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedDomain.Common;

namespace MedDomain.Entities;

[Table("role")]
public class Role : IEntity<int>
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Column("roletype_id")]
    public int RoletypeId { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey("RoletypeId")]
    [InverseProperty("Roles")]
    public virtual Roletype Roletype { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<UserModule> UserModules { get; set; } = new List<UserModule>();
}
