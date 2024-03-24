using MedDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedApplication.Common.EntityServices;

public interface IDoctorService
{
    /// <summary>
    /// Retrieves a collection of doctor based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the User object</returns>
    IQueryable<Doctor> Get(Expression<Func<Doctor,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a doctor by their unique identifier.
    /// </summary>
    /// <param name="doctorsId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the User object.</returns>
    ValueTask<Doctor?> GetByIdAsync(int doctorsId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of doctor based on a collection of user IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of User objects.</returns>
    //ValueTask<IEnumerable<UserModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="doctor"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created User object.</returns>
    ValueTask<Doctor> CreateAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing user.
    /// </summary>
    /// <param name="doctor"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated User object.</returns>
    ValueTask<Doctor> UpdateAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user by their unique identifier.
    /// </summary>
    /// <param name="doctorId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteByIdAsync(int doctorId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <param name="doctor"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted User object.</returns>
    void DeleteAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default);

}
