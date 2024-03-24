using MedApplication.Common.Constants;
using MedApplication.Common.Identity.Services;
using MedApplication.Common.Settings;
using MedDomain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MedInfrastructure.Common.Identity;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly JwtSettings _jwtSettings;

    public TokenGeneratorService(IOptions<JwtSettings> jwtSettings) => _jwtSettings = jwtSettings.Value;

    public string GetToken(UserModule user)
    {
        var jwtToken = GetJwtToken(user);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return token;
    }

    public JwtSecurityToken GetJwtToken(UserModule user)
    {
        var claims = GetClaims(user);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(_jwtSettings.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.ValidIssuer,
            audience: _jwtSettings.ValidAudience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationTimeInMinutes),
            signingCredentials: credentials);
    }

    public List<Claim> GetClaims(UserModule user)
    {
        return new List<Claim>
        {
            new (ClaimTypes.Email, user.EmailAddress),
            new (ClaimConstants.UserId, user.Id.ToString()),
            new (ClaimTypes.Role, user.Role.Name)
        };
    }
}
