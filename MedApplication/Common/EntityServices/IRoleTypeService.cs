using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface IRoletypeService
{
    /// <summary>
    /// Retrieves a collection of roleTypes based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the User object</returns>
    IQueryable<Roletype> Get(Expression<Func<Roletype,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a roleType by their unique identifier.
    /// </summary>
    /// <param name="roleTypesId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the User object.</returns>
    ValueTask<Roletype?> GetByIdAsync(int roleTypesId, bool asNoTracking = false, CancellationToken cancellationToken = default);

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
    ValueTask<Roletype> CreateAsync(Roletype roleType, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="roleType"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated User object.</returns>
    ValueTask<Roletype> UpdateAsync(Roletype roleType, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user by their unique identifier.
    /// </summary>
    /// <param name="roleTypeId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteByIdAsync(int roleTypeId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="roleType"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteAsync(Roletype roleType, bool saveChanges = true, CancellationToken cancellationToken = default);

}
