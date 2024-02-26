using MedDomain.Entities;

namespace MedPersistance.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> GetAllRoleAsync(bool trackChanges);
    Task<Role> GetRoleAsync(long entityId, bool trackChanges);
    Role CreateRole(Role entity);
    Role UpdateRole(Role entity);
    Task<IEnumerable<Role>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges);
    void DeleteRole(Role entity);
    IEnumerable<Role> CreateRoles(IEnumerable<Role> entities);
}