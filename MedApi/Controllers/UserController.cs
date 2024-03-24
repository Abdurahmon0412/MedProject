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

}