using AutoMapper;
using MedApplication.Common.EntityServices;
using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using System.Security.Authentication;


namespace MedInfrastructure.Common.Identity;

public class AuthService : IAuthService
{
    public AuthService(IMapper mapper,
    IPasswordGeneratorService passwordGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountService accountAggregatorService,
    // IUserSignInDetailsService userSignInDetailsService,
    ITokenGeneratorService accessTokenGeneratorService,
    IUserModuleService userService,
    IRoleService roleService,
    IOrganizationService organizationService)
    {
        _accountService = accountAggregatorService;
        _roleService = roleService;
        _passwordHasherService = passwordHasherService;
        _passwordGeneratorService = passwordGeneratorService;
        _mapper = mapper;
        _userService = userService;
        _roleService = roleService;
        _accessTokenGeneratorService = accessTokenGeneratorService;
        _organizationService = organizationService;
    }

    private readonly IOrganizationService _organizationService;
    private readonly ITokenGeneratorService _accessTokenGeneratorService;
    private readonly IMapper _mapper;
    private readonly IPasswordGeneratorService _passwordGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IRoleService _roleService;
    private readonly IUserModuleService _userService;
    public async ValueTask<string> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
    {
        var foundUser = await _userService.GetByEmailAddressAsync(signUpDetails.EmailAddress, cancellationToken: cancellationToken);

        if (foundUser != null)
            throw new Exception("User with this email address already exists.");

        // Hash password
        var user = _mapper.Map<UserModule>(signUpDetails);
        var password = signUpDetails.AutoGeneratePassword
            ? _passwordGeneratorService.GeneratePassword()
            : _passwordGeneratorService.GetValidatedPassword(signUpDetails.Password!, user);

        user.RoleId = await _roleService.GetDefaultRoleId(cancellationToken);
        var org = await _organizationService.GetByIdAsync(signUpDetails.OrganizationId, cancellationToken: cancellationToken);
        user.Role = await _roleService.GetByIdAsync(user.RoleId, cancellationToken: cancellationToken);
        user.OrganizationId = org.Id;
        user.RegionId = org.RegionId;
        user.OblastId = org.OblastId;
        user.LanguageId = 1;
        user.StatusId = 1;
        user.PasswordHash = _passwordHasherService.HashPassword(password);
        await _accountService.CreateUserModuleAsync(user, cancellationToken);

        return  _accessTokenGeneratorService.GetToken(user);
    }

    public async ValueTask<AccessToken> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default)
    {

        var foundUser = await _userService.GetByEmailAddressAsync(signInDetails.EmailAddress, cancellationToken: cancellationToken);

        if (foundUser is null || !_passwordHasherService.HashPassword(foundUser.PasswordHash).Equals(foundUser.PasswordHash))
            throw new AuthenticationException("Invalid email address or password.");

        await _accountService.CreateUserModuleAsync(foundUser, cancellationToken);
        // Validate login location
        //var locationValidationResult = await userSignInDetailsService.ValidateSignInLocation(cancellationToken);

        // // Notify user about changed location
        //
        // // Record login info
        //await userSignInDetailsService.RecordSignInAsync(false, cancellationToken);
        //
        // // Generate access token and save it
        //await accessTokenService.CreateAsync(foundUser.Id, tokenValue.Token, tokenValue.ExpiryTime, true, cancellationToken);
        var tokenValue = _accessTokenGeneratorService.GetToken(foundUser);
        return new AccessToken()
        {
            UserId = foundUser.Id,
            Token = tokenValue,
        };
    }

    public ValueTask<bool> GrandRoleAsync(long userId, string roleType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> RevokeRoleAsync(long userId, string roleType, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public ValueTask<AccessToken> RefreshTokenAsync(string refreshTokenValue, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}