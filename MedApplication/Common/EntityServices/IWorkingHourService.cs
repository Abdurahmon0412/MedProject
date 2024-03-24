using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface IWorkingHourService
{
    /// <summary>
    /// Retrieves a collection of workingHours based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the WorkingHour object</returns>
    IQueryable<WorkingHour> Get(Expression<Func<WorkingHour,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a workingHour by their unique identifier.
    /// </summary>
    /// <param name="workingHoursId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the WorkingHour object.</returns>
    ValueTask<WorkingHour?> GetByIdAsync(int workingHoursId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of workingHours based on a collection of workingHour IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of WorkingHour objects.</returns>
    //ValueTask<IEnumerable<WorkingHourModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new workingHour.
    /// </summary>
    /// <param name="workingHour"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created WorkingHour object.</returns>
    ValueTask<WorkingHour> CreateAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing workingHour.
    /// </summary>
    /// <param name="workingHour"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated WorkingHour object.</returns>
    ValueTask<WorkingHour> UpdateAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a workingHour by their unique identifier.
    /// </summary>
    /// <param name="workingHourId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted WorkingHour object.</returns>
    void DeleteByIdAsync(int workingHourId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a workingHour.
    /// </summary>
    /// <param name="workingHour"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted WorkingHour object.</returns>
    void DeleteAsync(WorkingHour workingHour, bool saveChanges = true, CancellationToken cancellationToken = default);

}