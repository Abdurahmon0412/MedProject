using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Regions;

public class RegionRepository : EntityRepositoryBase<int, Region, MContext>, IRegionRepository
{
    public RegionRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Region> Get(Expression<Func<Region, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Region?> GetByIdAsync(int regionId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(regionId, asNoTracking, cancellationToken);

    public new ValueTask<Region> CreateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(region, saveChanges, cancellationToken);

    public new ValueTask<Region> UpdateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(region, saveChanges, cancellationToken);

    public ValueTask<Region> DeleteByIdAsync(int regionId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(regionId, cancellationToken: cancellationToken);
    }

    public ValueTask<Region> DeleteAsync(Region region, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(region, cancellationToken: cancellationToken);
    }
}