using MedDomain.Enums;

namespace MedApplication.Common.Notification.Models;

public class NotificationRequest
{
    public long? SenderUserId { get; set; }
    
    public long ReceiverUserId { get; set; }

    public NotificationTemplateType TemplateType { get; set; }

    public NotificationType? Type { get; set; } = null;

    public Dictionary<string, string>? Variables { get; set; }
}