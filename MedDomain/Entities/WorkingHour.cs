using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("working_hours")]
public  class WorkingHour : IEntity<int>
{
    public WorkingHour()
    {
        DoctorInfos = new HashSet<DoctorInfo>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("from_time", TypeName = "timestamp without time zone")]
    public DateTime? FromTime { get; set; }
    [Column("to_time", TypeName = "timestamp without time zone")]
    public DateTime? ToTime { get; set; }
    [Column("week_day_id")]
    public int WeekDayId { get; set; }
    [Column("created_date", TypeName = "timestamp without time zone")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(WeekDayId))]
    [InverseProperty("WorkingHours")]
    public virtual WeekDay WeekDay { get; set; } = null!;
    [InverseProperty(nameof(DoctorInfo.WorkingHours))]
    public virtual ICollection<DoctorInfo> DoctorInfos { get; set; }
}
