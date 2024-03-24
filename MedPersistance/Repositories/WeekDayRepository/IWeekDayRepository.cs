using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.WeekDays;

public interface IWeekDayRepository
{
    IQueryable<WeekDay> Get(Expression<Func<WeekDay, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<WeekDay?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<WeekDay> CreateAsync(WeekDay gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<WeekDay> UpdateAsync(WeekDay gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<WeekDay> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<WeekDay> DeleteAsync(WeekDay gender, CancellationToken cancellationToken = default);
}