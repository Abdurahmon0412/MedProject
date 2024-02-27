namespace MedDomain.Enums;

public enum NotificationType
{
    Email = 0,
    Sms = 1
}

public enum NotificationTemplateType
{
    WelcomeNotification = 0,
    EmailAddressVerificationNotification = 1,
    PhoneNumberVerificationNotification = 2,
    ReferralNotification = 3,
}

public enum VerificationCodeType
{
    EmailAddressVerification,
    PhoneNumberVerification,
    AccountDeleteVerification
}

public enum VerificationType
{
    UserActionVerificationCode = 0,
    UserInfoVerificationCode = 1
}