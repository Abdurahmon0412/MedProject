using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.Identity.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers;

//[Authorize(Roles = "Admin")]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserModuleService _userModuleService;
    public UserController(IUserModuleService userModuleService)
    {
        _userModuleService = userModuleService;
    }

    [HttpGet("{userId:long}")]
    public async ValueTask<IActionResult> GetById([FromRoute] long userId)
    {
        var result = await _userModuleService.GetByIdAsync(userId);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        return Ok(_userModuleService.Get());
    }

    //[Authorize]
    [HttpGet("userId")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await _userModuleService.GetByIdAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long Id)
    {
        return Ok(await _userModuleService.DeleteByIdAsync(Id));
    }

}