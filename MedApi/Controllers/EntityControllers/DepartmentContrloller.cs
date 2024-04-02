using MedApplication.Common.Dtos.Department;
using MedApplication.Common.EntityServices;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers.EntityControllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentContrloller : ControllerBase
{
    private readonly IDepartmentService _departmentService;
    public DepartmentContrloller(IDepartmentService departmentService) => _departmentService = departmentService;

    [HttpPost("CreateDepartment")]
    public async Task<IActionResult> CreateDepartmentAsync([FromBody] DepartmentForCreationDto dto)
    {
        return Ok(value: await _departmentService.CreateAsync(dto));
    }

    [HttpGet("departments")]
    public async Task<IActionResult> GetAllDepartmentsAsync()
    {
        return Ok(_departmentService.Get());
    }

    //[Authorize]
    [HttpGet("departmentId")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        return Ok(await _departmentService.GetByIdAsync(id));
    }

    [HttpPut("updateDepartment")]
    public async Task<IActionResult> UpdateAsync([FromBody] DepartmentForUpdateDto dto)
    {
        return Ok(await _departmentService.UpdateAsync(dto));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] int Id)
    {
        return Ok(await _departmentService.DeleteByIdAsync(Id));
    }
}
