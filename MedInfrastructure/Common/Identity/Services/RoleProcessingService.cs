using System.Security.Authentication;
using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedInfrastructure.Common.Identity.Services;

/// <summary>
/// Provides services for managing user roles within the application.
/// </summary>
public class RoleProcessingService : IRoleProcessingService
{
    private readonly IRoleService _roleService;
    private readonly IUserModuleService _userModuleService;
    private readonly IRoleRepository _roleRepository;
    public RoleProcessingService(
    IUserModuleService userService,
    IRoleService roleService,
    IRoleRepository roleRepository)
    {
        _roleService = roleService;
        _userModuleService = userService;
        _roleRepository = roleRepository;

    }

    public async ValueTask GrandRoleAsync(long userId, Roletype roleType, Roletype actionUserRole, CancellationToken cancellationToken = default)
    {
        // Query user
        var user = await _userModuleService.Get(asNoTracking: true)
                       .Include(user => user.Role)
                       .FirstOrDefaultAsync(user => user.Id == userId, cancellationToken: cancellationToken) ??
                   throw new InvalidOperationException("User not found");

        // Validate action permission
        //if (actionUserRole <= Roletype || actionUserRole <= roleType)
        //    throw new AuthenticationException("User does not have permission to grand a role");
        var roles = _roleRepository.GetAllRoleAsync(false);

        if (_roleRepository.GetAllRoleAsync(_roleService.GetByTypeAsync(roleType)).  Roles.Any(role => role.Type == roleType))
            throw new InvalidOperationException("User already has the role");

        // Query selected role
        var selectedRole = await roleService.GetByTypeAsync(roleType, cancellationToken: cancellationToken) ??
                           throw new InvalidOperationException("Role not found");

        // Add role to user
        await _userRoleRepository.CreateAsync(
            new UserRole
            {
                RoleId = selectedRole.Id,
                UserId = user.Id
            },
            cancellationToken: cancellationToken
        );
    }

    public async ValueTask GrandRoleBySystemAsync(Guid userId, Roletype roleType, CancellationToken cancellationToken = default)
    {
        //var user = await userService.Get(asNoTracking: true)
        //               .Include(user => user.Roles)
        //               .FirstOrDefaultAsync(user => user.Id == userId, cancellationToken: cancellationToken) ??
        //           throw new InvalidOperationException("User not found");

        //if (user.Roles.Any(role => role.Type == roleType))
        //    throw new InvalidOperationException("User already has the role");

        //// Query selected role
        //var selectedRole = await roleService.GetByTypeAsync(roleType, cancellationToken: cancellationToken) ??
        //                   throw new InvalidOperationException("Role not found");

        //// Add role to user
        //await userRoleRepository.CreateAsync(
        //    new UserRole
        //    {
        //        RoleId = selectedRole.Id,
        //        UserId = user.Id
        //    },
        //    cancellationToken: cancellationToken
        //);
    }

    public async ValueTask RevokeRoleAsync(Guid userId, Roletype roleType, Roletype actionUserRole, CancellationToken cancellationToken = default)
    {
        //var user = await userService.Get(asNoTracking: true)
        //               .Include(user => user.Roles)
        //               .FirstOrDefaultAsync(user => user.Id == userId, cancellationToken: cancellationToken) ??
        //           throw new InvalidOperationException("User not found");

        ////Choosing the right role
        //var selectedRole = user.Roles.FirstOrDefault(role => role.Type == roleType) ??
        //                   throw new AuthenticationException("Given role wasn't granted to the user.");
        
        //// Validate action permission
        //if (actionUserRole <= Roletype.Host || actionUserRole <= roleType)
        //    throw new AuthenticationException("User does not have permission to grand a role");

        //// Delete the selected role
        //await userRoleRepository.DeleteAsync(
        //    new UserRole
        //    {
        //        RoleId = selectedRole.Id,
        //        UserId = user.Id
        //    },
        //    cancellationToken: cancellationToken
        //);
    }
}