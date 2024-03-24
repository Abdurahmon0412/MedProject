using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Regions;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class RegionService : IRegionService
{
    private readonly IRegionRepository _regionRepository;
    public RegionService(IRegionRepository regionRepository)
    {
        _regionRepository = regionRepository;
    }

    public IQueryable<Region> Get(Expression<Func<Region, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _regionRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Region?> GetByIdAsync(int regionId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _regionRepository.GetByIdAsync(regionId, asNoTracking, cancellationToken);
    }

    public ValueTask<Region> CreateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _regionRepository.CreateAsync(region, saveChanges, cancellationToken);
    }

    public ValueTask<Region> UpdateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _regionRepository.UpdateAsync(region, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int regionId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _regionRepository.DeleteByIdAsync(regionId, cancellationToken);
    

    public void DeleteAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _regionRepository.DeleteAsync(region, cancellationToken);
}