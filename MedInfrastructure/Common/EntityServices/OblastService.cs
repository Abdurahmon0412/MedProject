using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.OblastRepository;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class OblastService : IOblastService
{
    private readonly IOblastRepository _oblastRepository;
    public OblastService(IOblastRepository oblastRepository)
    {
        _oblastRepository = oblastRepository;
    }

    public IQueryable<Oblast> Get(Expression<Func<Oblast, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _oblastRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Oblast?> GetByIdAsync(int oblastId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _oblastRepository.GetByIdAsync(oblastId, asNoTracking, cancellationToken);
    }

    public ValueTask<Oblast> CreateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _oblastRepository.CreateAsync(oblast, saveChanges, cancellationToken);
    }

    public ValueTask<Oblast> UpdateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _oblastRepository.UpdateAsync(oblast, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int oblastId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _oblastRepository.DeleteByIdAsync(oblastId, cancellationToken);
    

    public void DeleteAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _oblastRepository.DeleteAsync(oblast, cancellationToken);
}