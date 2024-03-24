using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.WorkingHours;

public interface IWorkingHourRepository
{
    IQueryable<WorkingHour> Get(Expression<Func<WorkingHour, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<WorkingHour?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<WorkingHour> CreateAsync(WorkingHour gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<WorkingHour> UpdateAsync(WorkingHour gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<WorkingHour> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<WorkingHour> DeleteAsync(WorkingHour gender, CancellationToken cancellationToken = default);
}