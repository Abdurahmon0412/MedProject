using MedDomain.Entities;

namespace MedPersistance.Repositories.Interfaces;

public interface IUserModuleRepository
{
    IQueryable<UserModule> GetAllUserModuleAsync(bool trackChanges);
    Task<UserModule> GetUserModuleAsync(long entityId, bool trackChanges);
    UserModule CreateUserModule(UserModule entity);
    UserModule UpdateUserModule(UserModule entity);
    Task<IEnumerable<UserModule>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges);
    void DeleteUserModule(UserModule entity);
    IEnumerable<UserModule> CreateUserModules(IEnumerable<UserModule> entities);
}
