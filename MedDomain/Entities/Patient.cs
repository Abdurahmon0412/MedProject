﻿using MedDomain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedDomain.Entities;

[Table("patient")]
public class Patient : IEntity<int>
{
    public Patient()
    {
        Doctors = new HashSet<Doctor>();
    }

    [Key]
    [Column("id")]
    public int Id { get; set; }
    [Column("first_name")]
    [StringLength(100)]
    public string? FirstName { get; set; }
    [Column("last_name")]
    [StringLength(100)]
    public string? LastName { get; set; }
    [Column("diagnose_id")]
    public int DiagnoseId { get; set; }
    [Column("organization_id")]
    public int OrganizationId { get; set; } 
    [Column("examination_id")]
    public int ExaminationId { get; set; }
    [Column("payment_id")]
    public int PaymentId { get; set; }
    [Column("user_module_id")]
    public long UserModuleId { get; set; }
    [Column("address_id")]
    public int AddressId { get; set; }
    [Column("date_of_birth", TypeName = "timestamp with time zone")]
    public DateTime? DateOfBirth { get; set; }
    [Column("queue_number")]
    public int? QueueNumber { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("created_user_id")]
    public int? CreatedUserId { get; set; }
    [Column("modified_date", TypeName = "timestamp with time zone")]
    public DateTime? ModifiedDate { get; set; }
    [Column("modified_user_id")]
    public int? ModifiedUserId { get; set; }

    [ForeignKey(nameof(AddressId))]
    [InverseProperty("Patients")]
    public virtual Address Address { get; set; } = null!;
    [ForeignKey(nameof(DiagnoseId))]
    [InverseProperty("Patients")]
    public virtual Diagnose Diagnose { get; set; } = null!;
    [ForeignKey(nameof(ExaminationId))]
    [InverseProperty("Patients")]
    public virtual Examination Examination { get; set; } = null!;
    [ForeignKey(nameof(OrganizationId))]
    [InverseProperty("Patients")]
    public virtual Organization Organization { get; set; } = null!;
    [ForeignKey(nameof(PaymentId))]
    [InverseProperty("Patients")]
    public virtual Payment Payment { get; set; } = null!;
    [ForeignKey(nameof(UserModuleId))]
    [InverseProperty("Patients")]
    public virtual UserModule UserModule { get; set; } = null!;
    [InverseProperty(nameof(Doctor.Patient))]
    public virtual ICollection<Doctor> Doctors { get; set; }
}
