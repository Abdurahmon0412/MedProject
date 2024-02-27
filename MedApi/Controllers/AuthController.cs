using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Common.Query;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    #region Authentication
    
    [HttpPost("sign-up")]
    public async ValueTask<IActionResult> SignUp([FromBody] SignUpDetails signUpDetails, CancellationToken cancellationToken)
    {
        var result = await _authService.SignUpAsync(signUpDetails, cancellationToken);
        return result ? Ok() : BadRequest();
    }
    #endregion

    #region Roles

    [HttpGet("roles")]
    public async ValueTask<IActionResult> GetRoles(
        [FromQuery] FilterPagination paginationOptions,
        [FromServices] IRoleService roleService,
        CancellationToken cancellationToken
    )
    {
        var result = await roleService.GetByFilterAsync(paginationOptions, true, cancellationToken);
        return Ok(result);
    }

    #endregion
}