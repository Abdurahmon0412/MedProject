using MedApi.Models;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.EntityServices;
using MedInfrastructure.Common.EntityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedApi.Controllers.EntityControllers;


[ApiController]
[Route("api/[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationService _organizationService;
    public OrganizationController(IOrganizationService organizationService) => _organizationService = organizationService;

    [HttpPost]
    public async Task<IActionResult> CreateOrganizationAsync([FromBody] OrganizationForCreationDto dto)
    {
        return Ok(value: await _organizationService.CreateAsync(dto));
    }

    [HttpGet("organizations")]
    public async Task<IActionResult> GetAllOrganizationsAsync()
    {
        return Ok(_organizationService.Get());
    }

    [HttpGet("GetAllPatientsByOrganizationId")]
    public async Task<IActionResult> GetAllPatientsByDepartmentId(int organizationId)
    {
        return Ok(value: await _organizationService.GetAllPatientsByOrganizationId(organizationId, true));
    }

    //[Authorize]
    [HttpGet("organizationId")]
    public async Task<IActionResult> GetOrganizationById(int id)
    {
        return Ok(await this._organizationService.GetByIdAsync(id));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] OrganizationForUpdateDto dto)
    {
        return Ok(await _organizationService.UpdateAsync(dto));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] int Id)
    {
        return Ok(await _organizationService.DeleteByIdAsync(Id));
    }
}
