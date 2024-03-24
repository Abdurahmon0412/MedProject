using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedApplication.Common.EntityServices;

public interface ILanguageService
{
    /// <summary>
    /// Retrieves a collection of languages based on the specified predicate.
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>Returning the Language object</returns>
    IQueryable<Language> Get(Expression<Func<Language,
        bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Retrieves a Language by their unique identifier.
    /// </summary>
    /// <param name="languagesId"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the Language object.</returns>
    ValueTask<Language?> GetByIdAsync(int languagesId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of Languages based on a collection of Language IDs.
    /// </summary>
    /// <param name="ids"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning a list of Language objects.</returns>
    //ValueTask<IEnumerable<LanguageModule>> GetByIdsAsync(IEnumerable<long> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new Language.
    /// </summary>
    /// <param name="Language"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the created Language object.</returns>
    ValueTask<Language> CreateAsync(Language Language, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing Language.
    /// </summary>
    /// <param name="Language"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the updated Language object.</returns>
    ValueTask<Language> UpdateAsync(Language Language, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Language by their unique identifier.
    /// </summary>
    /// <param name="languageId"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted Language object.</returns>
    void DeleteByIdAsync(int languageId, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a Language.
    /// </summary>
    /// <param name="Language"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Returning the deleted Language object.</returns>
    void DeleteAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default);

}
