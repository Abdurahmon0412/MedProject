using MedApplication.Common.Identity.Services;
using MedDomain.Entities;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedInfrastructure.Common.Identity.Services;


/// <summary>
/// Service responsible for retrieving roles based on the provided role type.
/// </summary>
public class RoleService : IRoleService
{
    public RoleService(IRoleRepository roleRepository)
    {
        
    }

    private readonly IRoleRepository _roleRepository;
    public async ValueTask<Role?> GetByTypeAsync(Roletype roleType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _roleRepository.GetAllRoleAsync(trackChanges: asNoTracking)
            .FirstOrDefaultAsync(role => role.Roletype == roleType, cancellationToken);
    }
}
