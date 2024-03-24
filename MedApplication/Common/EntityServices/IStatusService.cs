using MedDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedApplication.Common.EntityServices;

public interface IStatusService
{
    /// <summary>
    /// Retrieves a collection of statuss based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the status object</returns>
    IQueryable<Status> Get(Expression<Func<Status,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a status by their unique identifier.
    /// </summary>
    /// <param name="statussId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the status object.</returns>
    ValueTask<Status?> GetByIdAsync(int statussId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of statuss based on a collection of status IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of status objects.</returns>
    //ValueTask<IEnumerable<statusModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new status.
    /// </summary>
    /// <param name="status"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created status object.</returns>
    ValueTask<Status> CreateAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing status.
    /// </summary>
    /// <param name="status"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated status object.</returns>
    ValueTask<Status> UpdateAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a status by their unique identifier.
    /// </summary>
    /// <param name="statusId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted status object.</returns>
    void DeleteByIdAsync(int statusId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a status.
    /// </summary>
    /// <param name="status"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted status object.</returns>
    void DeleteAsync(Status status, bool saveChanges = true, CancellationToken cancellationToken = default);

}
