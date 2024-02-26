using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedPersistance.Repositories;

public class UserModuleRepository : RepositoryBase<UserModule>, IUserModuleRepository
{
    public UserModuleRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<UserModule> GetAllUserModuleAsync(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id);

    public async Task<IEnumerable<UserModule>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

    public async Task<UserModule> GetUserModuleAsync(long entityId, bool trackChanges) =>
        await FindByConditionWithIncludes(c => c.Id.Equals(entityId), trackChanges).SingleOrDefaultAsync();

    public UserModule CreateUserModule(UserModule entity)
    {
        var updatedEntity = SetEntityProperties(entity);
        var createdEntity = Create(entity);
        return createdEntity;
    }

    public IEnumerable<UserModule> CreateUserModules(IEnumerable<UserModule> entities)
    {
        CreateRange(entities);
        return entities;
    }

    public UserModule UpdateUserModule(UserModule entity)
    {
        var updatedEntity = Update(entity);
        return updatedEntity;
    }

    public void DeleteUserModule(UserModule entity)
    {
        Delete(entity);
    }

    private UserModule SetEntityProperties(UserModule entity)
    {
        return entity;
    }
}
