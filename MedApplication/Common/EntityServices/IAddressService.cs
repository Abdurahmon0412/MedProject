using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface IAddressService
{
    /// <summary>
    /// Retrieves a collection of addresses based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the User object</returns>
    IQueryable<Address> Get(Expression<Func<Address,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a organization by their unique identifier.
    /// </summary>
    /// <param name="addresessId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the User object.</returns>
    ValueTask<Address?> GetByIdAsync(int addressesId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of users based on a collection of user IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of User objects.</returns>
    //ValueTask<IEnumerable<Address>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created User object.</returns>
    ValueTask<Address> CreateAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="address"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated User object.</returns>
    ValueTask<Address> UpdateAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user by their unique identifier.
    /// </summary>
    /// <param name="organizationId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteByIdAsync(int addressId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="organization"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default);

}