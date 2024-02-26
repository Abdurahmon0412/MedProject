using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedInfrastructure.Common.Identity.Services;

public class AccountService : IAccountService

{
    private readonly IUserModuleService _userModuleService;
    private readonly IUserModuleRepository _userModuleRepository;

    public AccountService(
        IUserModuleService userService,
        IUserModuleRepository userRepository)
    {
        
    }

    public async ValueTask<UserModule?> GetUserModuleByEmailAddressAsync(
        string emailAddress,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return await _userModuleRepository.GetAllUserModuleAsync(trackChanges: asNoTracking)
            .FirstOrDefaultAsync(user => user.EmailAddress == emailAddress, cancellationToken: cancellationToken);
    }

    public async ValueTask<UserModule> CreateUserModuleAsync(UserModule user, CancellationToken cancellationToken = default)
    {
        // Create user
        var createdUserModule = await _userModuleService.CreateAsync(user, cancellationToken: cancellationToken);
       
        // TODO 
        // Create user settings
       
        
        // Send welcome email

        return createdUserModule;
    }

    public async ValueTask<bool> VerifyUserModuleAsync(string code, CancellationToken cancellationToken = default)
    {
        //var userVerifyCode = await userInfoVerificationCodeService.GetByCodeAsync(code, cancellationToken);

        //if (!userVerifyCode.IsValid) return false;

        //var user = await userService.GetByIdAsync(userVerifyCode.Code.UserModuleId, cancellationToken: cancellationToken) ??
        //           throw new InvalidOperationException();

        //switch (userVerifyCode.Code.CodeType)
        //{
        //    case VerificationCodeType.EmailAddressVerification:
        //        user.IsEmailAddressVerified = true;
        //        await userService.UpdateAsync(user, false, cancellationToken);
        //        break;
        //    default: throw new NotSupportedException();
        //}

        //await userInfoVerificationCodeService.DeactivateAsync(userVerifyCode.Code.Id, cancellationToken: cancellationToken);

        return true;
    }
}