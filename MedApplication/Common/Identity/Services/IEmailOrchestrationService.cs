using MedApplication.Common.Notification.Models;
using MedDomain.Exceptions;

namespace MedApplication.Common.Identity.Services;

public interface IEmailOrchestrationService
{
    ValueTask<FuncResult<bool>> SendAsync(
        EmailNotificationRequest request,
        CancellationToken cancellationToken = default
    );
}