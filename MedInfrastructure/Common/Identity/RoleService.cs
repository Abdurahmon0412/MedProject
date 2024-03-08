using MedApplication.Common.Identity.Services;
using MedDomain.Common.Query;
using MedDomain.Entities;
using MedPersistance.Extentions;
using MedPersistance.Repositories.Roles;
using Microsoft.EntityFrameworkCore;

namespace MedInfrastructure.Common.Identity;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;
    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async ValueTask<IList<Role>> GetByFilterAsync(
        FilterPagination filterOptions,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        return await _roleRepository.Get(asNoTracking: asNoTracking).ApplyPagination(filterOptions).ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<Role?> GetByTypeAsync(Roletype roleType, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return await _roleRepository.Get(role => role.Roletype == roleType, asNoTracking: asNoTracking).FirstOrDefaultAsync(cancellationToken);
    }

    public async ValueTask<int> GetDefaultRoleId(CancellationToken cancellationToken = default)
    {
        var roleId = await _roleRepository.Get(role => role.Roletype == role.Roletype, true)
            .Select(role => role.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return roleId;
    }
}