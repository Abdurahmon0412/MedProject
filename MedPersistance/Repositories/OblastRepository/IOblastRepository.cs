using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.OblastRepository;

public interface IOblastRepository
{
    IQueryable<Oblast> Get(Expression<Func<Oblast, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Oblast?> GetByIdAsync(int oblastId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Oblast> CreateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Oblast> UpdateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Oblast> DeleteByIdAsync(int oblastId, CancellationToken cancellationToken = default);

    ValueTask<Oblast> DeleteAsync(Oblast oblast, CancellationToken cancellationToken = default);
}
