using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Interfaces;

public interface IUserModuleRepository
{
    IQueryable<UserModule> Get(Expression<Func<UserModule, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<UserModule?> GetByIdAsync(long userId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<UserModule> CreateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserModule> UpdateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserModule> DeleteByIdAsync(long userId, CancellationToken cancellationToken = default);

    ValueTask<UserModule> DeleteAsync(UserModule user, CancellationToken cancellationToken = default);

}
