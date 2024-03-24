using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface IWeekDayService
{
    /// <summary>
    /// Retrieves a collection of weekDays based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the WeekDay object</returns>
    IQueryable<WeekDay> Get(Expression<Func<WeekDay,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a weekDay by their unique identifier.
    /// </summary>
    /// <param name="weekDaysId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the WeekDay object.</returns>
    ValueTask<WeekDay?> GetByIdAsync(int weekDaysId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of weekDays based on a collection of weekDay IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of WeekDay objects.</returns>
    //ValueTask<IEnumerable<WeekDayModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new weekDay.
    /// </summary>
    /// <param name="weekDay"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created WeekDay object.</returns>
    ValueTask<WeekDay> CreateAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing weekDay.
    /// </summary>
    /// <param name="weekDay"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated WeekDay object.</returns>
    ValueTask<WeekDay> UpdateAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a weekDay by their unique identifier.
    /// </summary>
    /// <param name="weekDayId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted WeekDay object.</returns>
    void DeleteByIdAsync(int weekDayId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a weekDay.
    /// </summary>
    /// <param name="weekDay"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted WeekDay object.</returns>
    void DeleteAsync(WeekDay weekDay, bool saveChanges = true, CancellationToken cancellationToken = default);

}