using MedApplication.Common.Identity.Services;
using MedApplication.Common.Notification.Models;
using MedDomain.Constants;
using MedDomain.Entities;
using MedDomain.Enums;

namespace LocalIdentity.SimpleInfra.Infrastructure.Common.Identity.Services;

public class AccountService : IAccountService
{
    private readonly IUserModuleService _userModuleService;
    private readonly IEmailOrchestrationService _emailOrchestrationService;
    public AccountService(
    IUserModuleService userService,
    IEmailOrchestrationService emailOrchestrationService)
    {
        _emailOrchestrationService = emailOrchestrationService;
        _userModuleService = userService;
    }

    public async ValueTask<UserModule> CreateUserModuleAsync(UserModule user, CancellationToken cancellationToken = default)
    {
        // create user not Async yet
        var createdUser = await _userModuleService.CreateAsync(user, cancellationToken: cancellationToken);

        // send welcome email
        var systemUser = await _userModuleService.GetSystemUserAsync(cancellationToken: cancellationToken);
        await _emailOrchestrationService.SendAsync(
            new EmailNotificationRequest
            {
                SenderUserId = systemUser.Id,
                ReceiverUserId = createdUser.Id,
                TemplateType = NotificationTemplateType.WelcomeNotification,
                Variables = new Dictionary<string, string>
                {
                    { NotificationTemplateConstants.UserNamePlaceholder, createdUser.FullName }
                }
            },
            cancellationToken
        );

        // send verification email
        var rd = new Random();
        var verificationCode = rd.Next(1000, 9999);
            //await userInfoVerificationCodeService.CreateAsync(
            //VerificationCodeType.EmailAddressVerification,
            //createdUser.Id,
            //cancellationToken);

        await _emailOrchestrationService.SendAsync(
            new EmailNotificationRequest
            {
                SenderUserId = systemUser.Id,
                ReceiverUserId = createdUser.Id,
                TemplateType = NotificationTemplateType.EmailAddressVerificationNotification,
                Variables = new Dictionary<string, string>
                {
                    { NotificationTemplateConstants.EmailAddressVerificationLinkPlaceholder, verificationCode.ToString() }
                }
            },
            cancellationToken
        );

        return createdUser;
    }
}