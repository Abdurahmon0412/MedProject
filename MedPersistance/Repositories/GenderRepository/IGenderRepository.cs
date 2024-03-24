using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Genders;

public interface IGenderRepository
{
    IQueryable<Gender> Get(Expression<Func<Gender, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Gender?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Gender> CreateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Gender> UpdateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Gender> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Gender> DeleteAsync(Gender gender, CancellationToken cancellationToken = default);
}