using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MedPersistance
{
    [Table("oblast")]
    public partial class Oblast
    {
        public Oblast()
        {
            Organizations = new HashSet<Organization>();
            Regions = new HashSet<Region>();
            UserModules = new HashSet<UserModule>();
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
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }
        [Column("created_user_id")]
        public int? CreatedUserId { get; set; }
        [Column("modified_date", TypeName = "timestamp without time zone")]
        public DateTime? ModifiedDate { get; set; }
        [Column("modified_user_id")]
        public int? ModifiedUserId { get; set; }

        [InverseProperty(nameof(Organization.Oblast))]
        public virtual ICollection<Organization> Organizations { get; set; }
        [InverseProperty(nameof(Region.Oblast))]
        public virtual ICollection<Region> Regions { get; set; }
        [InverseProperty(nameof(UserModule.Oblast))]
        public virtual ICollection<UserModule> UserModules { get; set; }
    }
}
