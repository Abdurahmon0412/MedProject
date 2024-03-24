using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.PlasticCards;

public interface IPlasticCardRepository
{
    IQueryable<PlasticCard> Get(Expression<Func<PlasticCard, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<PlasticCard?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<PlasticCard> CreateAsync(PlasticCard gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<PlasticCard> UpdateAsync(PlasticCard gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<PlasticCard> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<PlasticCard> DeleteAsync(PlasticCard gender, CancellationToken cancellationToken = default);
}