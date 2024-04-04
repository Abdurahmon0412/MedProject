using MedApplication.Common.Dtos;
using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface IExaminationService
{
    /// <summary>
    /// Retrieves a collection of organizations based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the User object</returns>
    IQueryable<ExaminationForResultDto> Get(Expression<Func<Examination,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a Examination by their unique identifier.
    /// </summary>
    /// <param name="examinationsId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the User object.</returns>
    ValueTask<ExaminationForResultDto?> GetByIdAsync(int examinationsId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of examination based on a collection of user IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of User objects.</returns>
    //ValueTask<IEnumerable<UserModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="examination"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created examination object.</returns>
    ValueTask<ExaminationForResultDto> CreateAsync(ExaminationForCreationDto examination, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing examination.
    /// </summary>
    /// <param name="examination"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated examination object.</returns>
    ValueTask<ExaminationForResultDto> UpdateAsync(ExaminationForUpdateDto examination, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a examination by their unique identifier.
    /// </summary>
    /// <param name="examinationId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted examination object.</returns>
    ValueTask<ExaminationForResultDto> DeleteByIdAsync(int examinationId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a examination.
    /// </summary>
    /// <param name="examination"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted examination object.</returns>
    void DeleteAsync(Examination examination, bool saveChanges = true, CancellationToken cancellationToken = default);

}
