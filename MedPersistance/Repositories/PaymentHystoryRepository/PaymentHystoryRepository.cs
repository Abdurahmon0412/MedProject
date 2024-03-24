using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.PaymentHystorys;

public class PaymentHystoryRepository : EntityRepositoryBase<int, PaymentHystory, MContext>, IPaymentHystoryRepository
{
    public PaymentHystoryRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<PaymentHystory> Get(Expression<Func<PaymentHystory, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<PaymentHystory?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<PaymentHystory> CreateAsync(PaymentHystory gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<PaymentHystory> UpdateAsync(PaymentHystory gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<PaymentHystory> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<PaymentHystory> DeleteAsync(PaymentHystory gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }
}