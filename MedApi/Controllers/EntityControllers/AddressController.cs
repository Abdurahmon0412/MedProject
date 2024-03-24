using MedApplication.Common.EntityServices;
using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedInfrastructure.Common.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedApi.Controllers.EntityControllers;


[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController(IAddressService addressService) => _addressService = addressService;

    [HttpGet("{addressId:int}")]
    public async ValueTask<IActionResult> GetAddress([FromRoute] int addressId)
    {
        var result = await _addressService.GetByIdAsync(addressId);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost("createAddress")]
    public async ValueTask<IActionResult> SignUp([FromBody] Address address, CancellationToken cancellationToken)
    {
        var result = await _addressService.CreateAsync(address, cancellationToken: cancellationToken);
        return result != null ? Ok(result) : BadRequest();
    }
}