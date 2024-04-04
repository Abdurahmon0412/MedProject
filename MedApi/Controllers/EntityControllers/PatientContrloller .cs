using MedApplication.Common.Dtos.Patient;
using MedApplication.Common.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers.EntityControllers;

[ApiController]
[Route("api/[controller]")]
public class PatientContrloller : ControllerBase
{
    private readonly IPatientService _patientService;
    public PatientContrloller(IPatientService patientService) => _patientService = patientService;

    [HttpPost("CreatePatient")]
    public async Task<IActionResult> CreatePatientAsync([FromBody] PatientForCreationDto dto)
    {
        return Ok(value: await _patientService.CreateAsync(dto));
    }

    [HttpGet("patients")]
    public async Task<IActionResult> GetAllPatientsAsync()
    {
        return Ok( _patientService.Get());
    }

    //[Authorize]
    [HttpGet("patientId")]
    public async Task<IActionResult> GetPatientById(int id)
    {
        return Ok(await _patientService.GetByIdAsync(id));
    }

    [HttpPut("updatePatient")]
    public async Task<IActionResult> UpdateAsync([FromBody] PatientForUpdateDto dto)
    {
        return Ok(await _patientService.UpdateAsync(dto));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] int Id)
    {
        return Ok(await _patientService.DeleteByIdAsync(Id));
    }
}
