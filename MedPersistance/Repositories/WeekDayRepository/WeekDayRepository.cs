using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.WeekDays;

public class WeekDayRepository : EntityRepositoryBase<int, WeekDay, MContext>, IWeekDayRepository
{
    public WeekDayRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<WeekDay> Get(Expression<Func<WeekDay, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<WeekDay?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<WeekDay> CreateAsync(WeekDay gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<WeekDay> UpdateAsync(WeekDay gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<WeekDay> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<WeekDay> DeleteAsync(WeekDay gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }
}