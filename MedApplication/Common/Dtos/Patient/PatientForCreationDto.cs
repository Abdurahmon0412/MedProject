namespace MedApplication.Common.Dtos.Patient;

public class PatientForCreationDto
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public int DiagnoseId { get; set; }
	public int OrganizationId { get; set; }
	public int ExaminationId { get; set; }
	public int PaymentId { get; set; }
	public int UserModuleId { get; set; }
	public int AddressId {  get; set; }
	public DateTime DateOfBirth { get; set; }
	public int QueueNumber { get; set; }
}