using MedDomain.Entities;

namespace MedApplication.Common.Identity.Services;
/// <summary>
/// Interface defining operations related to roles in the application.
/// </summary>
public interface IRoleService
{
    /// <summary>
    /// Retrieves a role based on the specified role type asynchronously.
    /// </summary>
    /// <param name="roleType">The type of role to retrieve.</param>
    /// <param name="asNoTracking">Flag indicating whether to use 'asNoTracking' while querying (default is false).</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A ValueTask representing the retrieved role (or null if not found).</returns>
    ValueTask<Role?> GetByTypeAsync(
        Roletype roleType,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    );
    /// <summary>
    /// Get by default Role by Id 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<int> GetDefaultRoleId(CancellationToken cancellationToken = default);

}