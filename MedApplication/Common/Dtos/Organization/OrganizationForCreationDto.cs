namespace MedApplication.Common.Dtos.Organization;

public class OrganizationForCreationDto
{
    public int Id { get; set; }
    public string ShortName { get; set; }

    public string FullName { get; set; }

    public string Address { get; set; }

    public string Pinfl {  get; set; }

    public string PhoneNumber { get; set; }

    public int OblastId { get; set; }

    public int RegionId { get; set; }
}
