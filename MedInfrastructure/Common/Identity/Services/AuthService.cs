using AirBnB.Infrastructure.Common.Identity.Services;
using AutoMapper;
using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Net;
using System.Security.Authentication;
using System.Security.Claims;

namespace MedInfrastructure.Common.Identity.Services;

/// <summary>
/// Encapsulates authentication-related functionality, such as user registration, login, and role management.
/// </summary>
public class AuthService : IAuthService
{
    public IUserModuleService _userModuleService { get; private set; }
    public IAccountService _accountService { get; private set; }
    public IRoleProcessingService _roleProcessingService {  get; private set; }
    public IIdentitySecurityTokenService _identitySecurityTokenService { get; private set; }
    public IPasswordHasherService _passwordHasherService { get; private set; }
    public IPasswordGeneratorService _passwordGeneratorService { get; private set; }
    public IIdentitySecurityTokenGeneratorService _identitySecurityTokenGeneratorService { get; private set; }
    public IHttpContextAccessor _httpContextAccessor { get; private set; }
    public IMapper _mapper { get; private set; } 
    public AuthService(IMapper mapper,
    IUserModuleService userService,
    IAccountService accountService,
    IRoleProcessingService roleProcessingService,
    IIdentitySecurityTokenService identitySecurityTokenService,
    IPasswordHasherService passwordHasherService,
    IPasswordGeneratorService passwordGeneratorService,
    IIdentitySecurityTokenGeneratorService identitySecurityTokenGeneratorService,
    IHttpContextAccessor httpContextAccessor)
    {
        _userModuleService = userService;
        _accountService = accountService;
        _roleProcessingService = roleProcessingService;
        _identitySecurityTokenService = identitySecurityTokenService;
        _passwordHasherService = passwordHasherService;
        _passwordGeneratorService = passwordGeneratorService;
        _identitySecurityTokenGeneratorService = identitySecurityTokenGeneratorService;
        _httpContextAccessor = httpContextAccessor;
        _mapper = mapper;
    }
    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        //Check that the user is in the database at the entered email address
        var foundUserId = await _userModuleService.GetByEmailAddressAsync(signUpDetails.EmailAddress, true, cancellationToken);
        if (foundUserId is not null)
            throw new InvalidOperationException("User with this email address already exists.");

        //Map the entered user object
        var user = _mapper.Map<UserModule>(signUpDetails);

        //Generating complex password
        var password = signUpDetails.AutoGeneratePassword
            ? _passwordGeneratorService.GeneratePassword()
            : _passwordGeneratorService.GetValidatedPassword(signUpDetails.Password!, user);

        //Hash password
        user.PasswordHash = _passwordHasherService.HashPassword(password);

        var createdUser = await _accountService.CreateUserModuleAsync(user, cancellationToken);

        // Grand guest role
        await _roleProcessingService.GrandRoleBySystemAsync(createdUser.Id, user.Role.Roletype, cancellationToken);

        // TODO : add other validation logic
        return createdUser is not null;
    }

    public async ValueTask<(AccessToken accessToken, RefreshToken refreshToken)> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken)
    {
        var foundUser = await _userModuleService.GetByEmailAddressAsync(signInDetails.EmailAddress, cancellationToken: cancellationToken);

        if (foundUser is null || !_passwordHasherService.ValidatePassword(signInDetails.Password, foundUser.PasswordHash))
            throw new AuthenticationException("Sign in details are invalid, contact support.");

        if (foundUser.EmailAddress is null)
            throw new AuthenticationException("Email address is not verified.");

        return await CreateTokens(foundUser, cancellationToken);
    }

    public async ValueTask<bool> GrandRoleAsync(Guid userId, string roleType, CancellationToken cancellationToken = default)
    {
        var grandRoleTask = () => _roleProcessingService.GrandRoleAsync(
            userId,
            roleValue,
            requestUserContextProvider.GetUserRole(),
            cancellationToken
        );
        var grandRoleValue = await grandRoleTask.GetValueAsync();

        if (grandRoleValue is { IsSuccess: false, Exception: not null })
            throw grandRoleValue.Exception;

        // TODO : Send role granted notification

        return true;
    }

    public async ValueTask<bool> RevokeRoleAsync(long userId, string roleType, CancellationToken cancellationToken = default)
    {
        if (!Enum.TryParse(roleType, out RoleType roleValue))
            throw new InvalidOperationException("Invalid role type provided.");

        var revokeRoleTask = () => _roleProcessingService.RevokeRoleAsync(
            userId,
            roleValue,
            requestUserContextProvider.GetUserRole(),
            cancellationToken
        );
        var grandRoleValue = await revokeRoleTask.GetValueAsync();

        if (grandRoleValue is { IsSuccess: false, Exception: not null })
            throw grandRoleValue.Exception;

        // TODO : Send role revoked notification

        return true;
    }

    public async ValueTask<AccessToken> RefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken = default)
    {
        var accessTokenValue = requestUserContextProvider.GetAccessToken();

        if (string.IsNullOrWhiteSpace(refreshTokenValue))
            throw new ArgumentException("Invalid identity security token value", nameof(refreshTokenValue));

        if (string.IsNullOrWhiteSpace(accessTokenValue))
            throw new InvalidOperationException("Invalid identity security token value");

        // Check refresh token and access token
        var refreshToken = await identitySecurityTokenService.GetRefreshTokenByValueAsync(refreshTokenValue, cancellationToken);
        if (refreshToken is null)
            throw new AuthenticationException("Please login again.");

        var accessToken = identitySecurityTokenGeneratorService.GetAccessToken(accessTokenValue);
        if (!accessToken.HasValue)
        {
            // Remove refresh token if access token is not valid
            await identitySecurityTokenService.RemoveRefreshTokenAsync(refreshTokenValue, cancellationToken);
            throw new InvalidOperationException("Invalid identity security token value");
        }
        
        var foundAccessToken = await identitySecurityTokenService.GetAccessTokenByIdAsync(accessToken.Value.AccessToken.Id, cancellationToken);

        // Remove refresh token and access token if user id is not same
        if (refreshToken.UserId != accessToken.Value.AccessToken.UserId)
        {
            await identitySecurityTokenService.RemoveRefreshTokenAsync(refreshTokenValue, cancellationToken);
            if(foundAccessToken is not null)
                await identitySecurityTokenService.RevokeAccessTokenAsync(accessToken.Value.AccessToken.Id, cancellationToken);
            
            throw new AuthenticationException("Please login again.");
        }

        var foundUser =
            await userService
                .Get(user => user.Id == accessToken.Value.AccessToken.UserId, true)
                .Include(user => user.Roles)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) ??
            throw new InvalidOperationException();

        // If access token exists, not revoked and still valid return it, otherwise remove
        if (foundAccessToken is not null && !foundAccessToken.IsRevoked)
        {
            if(!foundAccessToken.IsRevoked)
                return foundAccessToken;
            await identitySecurityTokenService.RemoveAccessTokenAsync(accessToken.Value.AccessToken.Id, cancellationToken);
        }
        
        // Generate access token
        var newAccessToken = identitySecurityTokenGeneratorService.GenerateAccessToken(foundUser);

        return await identitySecurityTokenService.CreateAccessTokenAsync(newAccessToken, cancellationToken: cancellationToken);
    }

    private async Task<(AccessToken AccessToken, RefreshToken RefreshToken)> CreateTokens(UserModule user, CancellationToken cancellationToken = default)
    {
        var accessToken = identitySecurityTokenGeneratorService.GenerateAccessToken(user);

        var refreshToken = identitySecurityTokenGeneratorService.GenerateRefreshToken(user);

        return (await identitySecurityTokenService.CreateAccessTokenAsync(accessToken, cancellationToken: cancellationToken),
            await identitySecurityTokenService.CreateRefreshTokenAsync(refreshToken, cancellationToken: cancellationToken));
    }
}