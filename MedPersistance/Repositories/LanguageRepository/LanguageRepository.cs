using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Languages;

public class LanguageRepository : EntityRepositoryBase<int, Language, MContext>, ILanguageRepository
{
    public LanguageRepository(MContext dbContext) : base(dbContext)
    {

    }

    public IQueryable<Language> Get(Expression<Func<Language, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Language?> GetByIdAsync(int languageId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(languageId, asNoTracking, cancellationToken);

    public new ValueTask<Language> CreateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(language, saveChanges, cancellationToken);

    public new ValueTask<Language> UpdateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(language, saveChanges, cancellationToken);

    public ValueTask<Language> DeleteByIdAsync(int languageId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(languageId, cancellationToken: cancellationToken);
    }

    public ValueTask<Language> DeleteAsync(Language language, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(language, cancellationToken: cancellationToken);
    }
}