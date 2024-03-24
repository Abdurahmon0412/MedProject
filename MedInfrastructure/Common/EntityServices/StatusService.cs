using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.StatusRepositories;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;
    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public IQueryable<Status> Get(Expression<Func<Status, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _statusRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Status?> GetByIdAsync(int statusId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _statusRepository.GetByIdAsync(statusId, asNoTracking, cancellationToken);
    }

    public ValueTask<Status> CreateAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _statusRepository.CreateAsync(status, saveChanges, cancellationToken);
    }

    public ValueTask<Status> UpdateAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _statusRepository.UpdateAsync(status, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int statusId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _statusRepository.DeleteByIdAsync(statusId, cancellationToken);
    

    public void DeleteAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _statusRepository.DeleteAsync(status, cancellationToken);
}