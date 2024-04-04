using MedApplication.Common.Dtos;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers.EntityControllers;

[ApiController]
[Route("api/[controller]")]
public class ExaminationController : ControllerBase
{
    private readonly IExaminationService _examinationService;
    public ExaminationController(IExaminationService examinationService) => _examinationService = examinationService;

    [HttpPost("CreateExamination")]
    public async Task<IActionResult> CreatePatientAsync([FromBody] ExaminationForCreationDto dto)
    {
        return Ok(value: await _examinationService.CreateAsync(dto));
    }

    [HttpGet("examinations")]
    public async Task<IActionResult> GetAllExaminationsAsync()
    {
        return Ok(_examinationService.Get());
    }

    //[Authorize]
    [HttpGet("examinationId")]
    public async Task<IActionResult> GetExaminationById(int id)
    {
        return Ok(await _examinationService.GetByIdAsync(id));
    }

    [HttpPut("updatePatient")]
    public async Task<IActionResult> UpdateAsync([FromBody] ExaminationForUpdateDto dto)
    {
        return Ok(await _examinationService.UpdateAsync(dto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] int Id)
    {
        return Ok(await _examinationService.DeleteByIdAsync(Id));
    }
}