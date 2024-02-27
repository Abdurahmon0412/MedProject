using MedDomain.Enums;

namespace MedApplication.Common.Notification.Models;

public class EmailNotificationRequest : NotificationRequest
{
    public EmailNotificationRequest() => Type = NotificationType.Email;

    // attachments etc.
}