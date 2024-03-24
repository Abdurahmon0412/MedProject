using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Medicines;

public interface IMedicineRepository
{
    IQueryable<Medicine> Get(Expression<Func<Medicine, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Medicine?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Medicine> CreateAsync(Medicine gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Medicine> UpdateAsync(Medicine gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Medicine> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Medicine> DeleteAsync(Medicine gender, CancellationToken cancellationToken = default);
}