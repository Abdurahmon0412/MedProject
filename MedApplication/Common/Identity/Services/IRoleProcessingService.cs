using MedDomain.Entities;

namespace MedApplication.Common.Identity.Services;

public interface IRoleProcessingService
{
    /// <summary>
    /// Grands a specified role to a user
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="roleType">Type of role to grand.</param>
    /// <param name="actionUserRole">Role of user that requested grand role</param>
    /// <param name="cancellationToken">Cancellation token</param>
    ValueTask GrandRoleAsync(long userId, Roletype roleType, Roletype actionUserRole, CancellationToken cancellationToken = default);

    /// <summary>
    /// Grands a specified role to a user on behalf of system
    /// </summary>
    /// <param name="userId">User id</param>
    /// <param name="roleType">Type of role to grand.</param>
    /// <param name="cancellationToken">Cancellation token</param>
    ValueTask GrandRoleBySystemAsync(long userId, Roletype roleType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes a specified role from a user
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose role is being revoked</param>
    /// <param name="roleType">The type of role to revoke.</param>
    /// <param name="actionUserRole">Role of user that requested revoke role</param>
    /// <param name="cancellationToken"> A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that will complete with a value indicating whether the role was successfully revoked</returns>
    ValueTask RevokeRoleAsync(Guid userId, Roletype roleType, Roletype actionUserRole, CancellationToken cancellationToken = default);
}