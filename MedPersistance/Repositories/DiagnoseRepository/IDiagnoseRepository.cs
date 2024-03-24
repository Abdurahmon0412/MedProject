using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Diagnoses;

public interface IDiagnoseRepository
{
    IQueryable<Diagnose> Get(Expression<Func<Diagnose, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Diagnose?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Diagnose> CreateAsync(Diagnose gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Diagnose> UpdateAsync(Diagnose gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Diagnose> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Diagnose> DeleteAsync(Diagnose gender, CancellationToken cancellationToken = default);
}