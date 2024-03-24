using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.WorkingHours;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class WorkingHourService : IWorkingHourService
{
    private readonly IWorkingHourRepository _workingHourRepository;
    public WorkingHourService(IWorkingHourRepository workingHourRepository)
    {
        _workingHourRepository = workingHourRepository;
    }

    public IQueryable<WorkingHour> Get(Expression<Func<WorkingHour, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _workingHourRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<WorkingHour?> GetByIdAsync(int workingHourId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _workingHourRepository.GetByIdAsync(workingHourId, asNoTracking, cancellationToken);
    }

    public ValueTask<WorkingHour> CreateAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _workingHourRepository.CreateAsync(workingHour, saveChanges, cancellationToken);
    }

    public ValueTask<WorkingHour> UpdateAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _workingHourRepository.UpdateAsync(workingHour, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int workingHourId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _workingHourRepository.DeleteByIdAsync(workingHourId, cancellationToken);
    

    public void DeleteAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _workingHourRepository.DeleteAsync(workingHour, cancellationToken);
}