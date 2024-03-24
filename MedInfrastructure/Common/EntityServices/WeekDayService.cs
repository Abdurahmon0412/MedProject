using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.WeekDays;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class WeekDayService : IWeekDayService
{
    private readonly IWeekDayRepository _weekDayRepository;
    public WeekDayService(IWeekDayRepository weekDayRepository)
    {
        _weekDayRepository = weekDayRepository;
    }

    public IQueryable<WeekDay> Get(Expression<Func<WeekDay, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _weekDayRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<WeekDay?> GetByIdAsync(int weekDayId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _weekDayRepository.GetByIdAsync(weekDayId, asNoTracking, cancellationToken);
    }

    public ValueTask<WeekDay> CreateAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _weekDayRepository.CreateAsync(weekDay, saveChanges, cancellationToken);
    }

    public ValueTask<WeekDay> UpdateAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _weekDayRepository.UpdateAsync(weekDay, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int weekDayId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _weekDayRepository.DeleteByIdAsync(weekDayId, cancellationToken);
    

    public void DeleteAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _weekDayRepository.DeleteAsync(weekDay, cancellationToken);
}