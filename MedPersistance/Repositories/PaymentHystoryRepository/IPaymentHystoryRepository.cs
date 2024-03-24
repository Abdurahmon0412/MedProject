using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.PaymentHystorys;

public interface IPaymentHystoryRepository
{
    IQueryable<PaymentHystory> Get(Expression<Func<PaymentHystory, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<PaymentHystory?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<PaymentHystory> CreateAsync(PaymentHystory gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<PaymentHystory> UpdateAsync(PaymentHystory gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<PaymentHystory> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<PaymentHystory> DeleteAsync(PaymentHystory gender, CancellationToken cancellationToken = default);
}