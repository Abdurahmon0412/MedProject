using MedDomain.Entities;

namespace MedApplication.Common.Dtos.Doctor;

public class DoctorForResultDto
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int DoctorInfoId { get; set; }
    public int DepartmentId { get; set; }
    public long UserModuleId { get; set; }
    public int? PatientCountByDay { get; set; }
    public int DoctorPlaceId { get; set; }
    public int? PatientId { get; set; }
    public MedDomain.Entities.Patient? Patient { get; set; }
}
