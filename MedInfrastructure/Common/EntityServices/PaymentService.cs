using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Payments;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    public PaymentService(IPaymentRepository paymentRepository)
    {
        _paymentRepository = paymentRepository;
    }

    public IQueryable<Payment> Get(Expression<Func<Payment, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _paymentRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Payment?> GetByIdAsync(int paymentId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _paymentRepository.GetByIdAsync(paymentId, asNoTracking, cancellationToken);
    }

    public ValueTask<Payment> CreateAsync(Payment payment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _paymentRepository.CreateAsync(payment, saveChanges, cancellationToken);
    }

    public ValueTask<Payment> UpdateAsync(Payment payment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _paymentRepository.UpdateAsync(payment, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int paymentId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _paymentRepository.DeleteByIdAsync(paymentId, cancellationToken);
    

    public void DeleteAsync(Payment payment, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _paymentRepository.DeleteAsync(payment, cancellationToken);
}