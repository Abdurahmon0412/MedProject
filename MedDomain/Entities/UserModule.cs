using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedDomain.Common;

namespace MedDomain.Entities;
[Table("user_module")]
public class UserModule : IEntityLong
{
    [Key]
    [Column("id")]
    public long Id { get; set; }

    [Column("short_name")]
    [StringLength(100)]
    public string ShortName { get; set; } = null!;

    [Column("full_name")]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Column("user_name")]
    [StringLength(100)]
    public string UserName { get; set; } = null!;

    [Column("password")]
    [StringLength(100)]
    public string Password { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(100)]
    public string? PasswordHash { get; set; }

    [Column("password_salt")]
    [StringLength(100)]
    public string? PasswordSalt { get; set; }

    [Column("email_address")]
    [StringLength(100)]
    public string EmailAddress { get; set; } = null!;

    [Column("phone_number")]
    [StringLength(100)]
    public string PhoneNumber { get; set; } = null!;

    [Column("organization_id")]
    public int OrganizationId { get; set; }

    [Column("language_id")]
    public int LanguageId { get; set; }

    [Column("status_id")]
    public int StatusId { get; set; }

    [Column("oblast_id")]
    public int OblastId { get; set; }

    [Column("region_id")]
    public int RegionId { get; set; }

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("gender_id")]
    public int GenderId { get; set; }

    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }

    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }

    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }

    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey("GenderId")]
    [InverseProperty("UserModules")]
    public virtual Gender Gender { get; set; } = null!;

    [ForeignKey("LanguageId")]
    [InverseProperty("UserModules")]
    public virtual Language Language { get; set; } = null!;

    [ForeignKey("OblastId")]
    [InverseProperty("UserModules")]
    public virtual Oblast Oblast { get; set; } = null!;

    [ForeignKey("OrganizationId")]
    [InverseProperty("UserModules")]
    public virtual Organization Organization { get; set; } = null!;

    [ForeignKey("RegionId")]
    [InverseProperty("UserModules")]
    public virtual Region Region { get; set; } = null!;

    [ForeignKey("RoleId")]
    [InverseProperty("UserModules")]
    public virtual Role Role { get; set; } = null!;

    [ForeignKey("StatusId")]
    [InverseProperty("UserModules")]
    public virtual Status Status { get; set; } = null!;
}
