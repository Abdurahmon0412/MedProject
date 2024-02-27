using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedDomain.Common;

namespace MedDomain.Entities;

[Table("oblast")]
public class Oblast : IEntity<int>
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

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [InverseProperty("Oblast")]
    public virtual ICollection<Organization> Organizations { get; set; } = new List<Organization>();

    [InverseProperty("Oblast")]
    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    [InverseProperty("Oblast")]
    public virtual ICollection<UserModule> UserModules { get; set; } = new List<UserModule>();
}

