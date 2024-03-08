using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.StatusRepositories;

public interface IStatusRepository 
{
    IQueryable<Status> Get(Expression<Func<Status, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Status?> GetByIdAsync(int roleId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Status> CreateAsync(Status role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Status> UpdateAsync(Status role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Status> DeleteByIdAsync(int roleId, CancellationToken cancellationToken = default);

    ValueTask<Status> DeleteAsync(Status role, CancellationToken cancellationToken = default);
}
