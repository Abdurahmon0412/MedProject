using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.RoletypeRepositories;

public interface IRoletypeRepository
{
    IQueryable<Roletype> Get(Expression<Func<Roletype, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Roletype?> GetByIdAsync(int roleTypeId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Roletype> CreateAsync(Roletype roleType, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Roletype> UpdateAsync(Roletype roleType, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Roletype> DeleteByIdAsync(int roleTypeId, CancellationToken cancellationToken = default);

    ValueTask<Roletype> DeleteAsync(Roletype roleType, CancellationToken cancellationToken = default);
}
