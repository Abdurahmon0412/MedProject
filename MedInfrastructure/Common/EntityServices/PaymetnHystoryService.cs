using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.PaymentHystorys;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class PaymentHystoryService : IPaymentHystoryService
{
    private readonly IPaymentHystoryRepository _paymentHystoryRepository;
    public PaymentHystoryService(IPaymentHystoryRepository paymentHystoryRepository)
    {
        _paymentHystoryRepository = paymentHystoryRepository;
    }

    public IQueryable<PaymentHystory> Get(Expression<Func<PaymentHystory, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _paymentHystoryRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<PaymentHystory?> GetByIdAsync(int paymentHystoryId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _paymentHystoryRepository.GetByIdAsync(paymentHystoryId, asNoTracking, cancellationToken);
    }

    public ValueTask<PaymentHystory> CreateAsync(PaymentHystory paymentHystory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _paymentHystoryRepository.CreateAsync(paymentHystory, saveChanges, cancellationToken);
    }

    public ValueTask<PaymentHystory> UpdateAsync(PaymentHystory paymentHystory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _paymentHystoryRepository.UpdateAsync(paymentHystory, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int paymentHystoryId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _paymentHystoryRepository.DeleteByIdAsync(paymentHystoryId, cancellationToken);
    

    public void DeleteAsync(PaymentHystory paymentHystory, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _paymentHystoryRepository.DeleteAsync(paymentHystory, cancellationToken);
}