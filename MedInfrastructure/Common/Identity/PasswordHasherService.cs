using MedApplication.Common.Identity.Services;
using BC = BCrypt.Net.BCrypt;

namespace MedInfrastructure.Common.Identity;

public class PasswordHasherService : IPasswordHasherService
{
    public string HashPassword(string password)
    {
        return BC.HashPassword(password);
    }

    public bool ValidatePassword(string password, string hashedPassword)
    {
        return BC.Verify(password, hashedPassword);
    }
}