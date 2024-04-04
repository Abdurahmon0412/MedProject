using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Examinations;

public interface IExaminationRepository
{
    IQueryable<Examination> Get(Expression<Func<Examination, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Examination?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Examination> CreateAsync(Examination gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Examination> UpdateAsync(Examination gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Examination> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Examination> DeleteAsync(Examination gender, CancellationToken cancellationToken = default);

    IQueryable<Examination> SelectAll();
}