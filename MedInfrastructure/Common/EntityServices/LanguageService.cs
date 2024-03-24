using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Languages;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _languageRepository;
    public LanguageService(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public IQueryable<Language> Get(Expression<Func<Language, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _languageRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Language?> GetByIdAsync(int languageServiceId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _languageRepository.GetByIdAsync(languageServiceId, asNoTracking, cancellationToken);
    }

    public ValueTask<Language> CreateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _languageRepository.CreateAsync(language, saveChanges, cancellationToken);
    }

    public ValueTask<Language> UpdateAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _languageRepository.UpdateAsync(language, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int languageServiceId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _languageRepository.DeleteByIdAsync(languageServiceId, cancellationToken);
    

    public void DeleteAsync(Language language, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _languageRepository.DeleteAsync(language, cancellationToken);
}