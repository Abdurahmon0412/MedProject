using MedDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedApplication.Common.EntityServices;

public interface IRegionService
{
    /// <summary>
    /// Retrieves a collection of regions based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the User object</returns>
    IQueryable<Region> Get(Expression<Func<Region,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a region by their unique identifier.
    /// </summary>
    /// <param name="regionsId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the User object.</returns>
    ValueTask<Region?> GetByIdAsync(int regionsId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of users based on a collection of user IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of User objects.</returns>
    //ValueTask<IEnumerable<UserModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created User object.</returns>
    ValueTask<Region> CreateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated User object.</returns>
    ValueTask<Region> UpdateAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user by their unique identifier.
    /// </summary>
    /// <param name="regionId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteByIdAsync(int regionId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="region"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteAsync(Region region, bool saveChanges = true, CancellationToken cancellationToken = default);

}
