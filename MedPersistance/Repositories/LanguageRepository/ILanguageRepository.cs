using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Languages;
public interface ILanguageRepository
{
    IQueryable<Language> Get(Expression<Func<Language, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Language?> GetByIdAsync(int languageId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Language> CreateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Language> UpdateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Language> DeleteByIdAsync(int languageId, CancellationToken cancellationToken = default);

    ValueTask<Language> DeleteAsync(Language language, CancellationToken cancellationToken = default);
}               