using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPersistance.Repositories;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Role> GetAllRoleAsync(bool trackChanges) =>
             FindAll(trackChanges).OrderBy(c => c.Id);

    public async Task<IEnumerable<Role>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

    public async Task<Role> GetRoleAsync(long entityId, bool trackChanges) =>
        await FindByConditionWithIncludes(c => c.Id.Equals(entityId), trackChanges).SingleOrDefaultAsync();

    public Role CreateRole(Role entity)
    {
        var updatedEntity = SetEntityProperties(entity);
        var createdEntity = Create(entity);
        return createdEntity;
    }

    public IEnumerable<Role> CreateRoles(IEnumerable<Role> entities)
    {
        CreateRange(entities);
        return entities;
    }

    public Role UpdateRole(Role entity)
    {
        var updatedEntity = Update(entity);
        return updatedEntity;
    }

    public void DeleteRole(Role entity)
    {
        Delete(entity);
    }

    private Role SetEntityProperties(Role entity)
    {
        return entity;
    }
}
