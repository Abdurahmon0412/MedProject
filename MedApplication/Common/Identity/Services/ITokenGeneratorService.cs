using MedDomain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MedApplication.Common.Identity.Services;
public interface ITokenGeneratorService
{
    string GetToken(UserModule user);

    JwtSecurityToken GetJwtToken(UserModule user);

    List<Claim> GetClaims(UserModule user);
}