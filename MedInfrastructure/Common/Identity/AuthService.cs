using AutoMapper;
using MedApplication.Common.Identity.Models;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;


namespace MedInfrastructure.Common.Identity;

public class AuthService : IAuthService
{
    public AuthService(IMapper mapper,
    IPasswordGeneratorService passwordGeneratorService,
    IPasswordHasherService passwordHasherService,
    IAccountService accountAggregatorService,
    // IUserSignInDetailsService userSignInDetailsService,
    // IAccessTokenGeneratorService accessTokenGeneratorService,
    // IAccessTokenService accessTokenService,
    IUserModuleService userService,
    IRoleService roleService)
    {
        _accountService = accountAggregatorService;
        _roleService = roleService;
        _passwordHasherService = passwordHasherService;
        _passwordGeneratorService = passwordGeneratorService;
        _mapper = mapper;
        _userService = userService;
        _roleService = roleService;
    }

    private readonly IMapper _mapper;
    private readonly IPasswordGeneratorService _passwordGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IAccountService _accountService;
    private readonly IRoleService _roleService;
    private readonly IUserModuleService _userService;
    public async ValueTask<bool> SignUpAsync(SignUpDetails signUpDetails, CancellationToken cancellationToken = default)
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
        user.PasswordHash = _passwordHasherService.HashPassword(password);

        // Create user
        var createdUser = await _accountService.CreateUserModuleAsync(user, cancellationToken);
        return true;
    }
    
    public async ValueTask<AccessToken> SignInAsync(SignInDetails signInDetails, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();

        // var foundUser = await userService.GetByEmailAddressAsync(signInDetails.EmailAddress,  cancellationToken: cancellationToken);
        //
        // if (foundUser is null || !passwordHasherService.HashPassword(foundUser.PasswordHash).Equals(foundUser.PasswordHash))
        //     throw new AuthenticationException("Invalid email address or password.");
        //
        // // Validate login location
        // var locationValidationResult = await userSignInDetailsService.ValidateSignInLocation(cancellationToken);
        //
        // // Notify user about changed location
        //
        // // Record login info
        // await userSignInDetailsService.RecordSignInAsync(false, cancellationToken);
        //
        // // Generate access token and save it
        // var tokenValue = accessTokenGeneratorService.GetToken(foundUser);
        // return await accessTokenService.CreateAsync(foundUser.Id, tokenValue.Token, tokenValue.ExpiryTime, true, cancellationToken);
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