using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Regions;

public interface IRegionRepository
{
    IQueryable<Region> Get(Expression<Func<Region, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Region?> GetByIdAsync(int regionId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Region> CreateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Region> UpdateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Region> DeleteByIdAsync(int regionId, CancellationToken cancellationToken = default);

    ValueTask<Region> DeleteAsync(Region region, CancellationToken cancellationToken = default);
}