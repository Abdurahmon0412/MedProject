using MedDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedApplication.Common.EntityServices;

public interface IGenderService
{
    /// <summary>
    /// Retrieves a collection of Genders based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the Gender object</returns>
    IQueryable<Gender> Get(Expression<Func<Gender,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a Gender by their unique identifier.
    /// </summary>
    /// <param name="GendersId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the Gender object.</returns>
    ValueTask<Gender?> GetByIdAsync(int GendersId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of Genders based on a collection of Gender IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of Gender objects.</returns>
    //ValueTask<IEnumerable<GenderModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new Gender.
    /// </summary>
    /// <param name="Gender"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created Gender object.</returns>
    ValueTask<Gender> CreateAsync(Gender Gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing Gender.
    /// </summary>
    /// <param name="Gender"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated Gender object.</returns>
    ValueTask<Gender> UpdateAsync(Gender Gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Gender by their unique identifier.
    /// </summary>
    /// <param name="GenderId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted Gender object.</returns>
    void DeleteByIdAsync(int GenderId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Gender.
    /// </summary>
    /// <param name="Gender"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted Gender object.</returns>
    void DeleteAsync(Gender Gender, bool saveChanges = true, CancellationToken cancellationToken = default);

}
