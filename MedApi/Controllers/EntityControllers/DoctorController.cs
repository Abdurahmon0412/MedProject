using MedApplication.Common.Dtos.Doctor;
using MedApplication.Common.EntityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers.EntityControllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorController : ControllerBase
{
    private readonly IDoctorService _doctorService;
    public DoctorController(IDoctorService doctorService) => _doctorService = doctorService;

    [HttpPost]
    public async Task<IActionResult> CreateDcotorAsync([FromBody] DoctorForCreationDto dto)
    {
        return Ok(value: await _doctorService.CreateAsync(dto));
    }

    [HttpGet("GetDoctors")]
    public async Task<IActionResult> GetAllOrganizationsAsync()
    {
        return Ok(_doctorService.Get());
    }

    [Authorize]
    [HttpGet("doctorId")]
    public async Task<IActionResult> GetDoctorById(int id)
    {
        return Ok(await _doctorService.GetByIdAsync(id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] DoctorForUpdateDto dto)
    {
        return Ok(await _doctorService.UpdateAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] int Id)
    {
        return Ok(await _doctorService.DeleteByIdAsync(Id));
    }
}
