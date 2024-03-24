using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Payments;

public interface IPaymentRepository
{
    IQueryable<Payment> Get(Expression<Func<Payment, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Payment?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Payment> CreateAsync(Payment gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Payment> UpdateAsync(Payment gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Payment> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Payment> DeleteAsync(Payment gender, CancellationToken cancellationToken = default);
}