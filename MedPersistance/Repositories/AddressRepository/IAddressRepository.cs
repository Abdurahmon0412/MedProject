using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Addresss;

public interface IAddressRepository
{
    IQueryable<Address> Get(Expression<Func<Address, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Address?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Address> CreateAsync(Address gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Address> UpdateAsync(Address gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Address> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Address> DeleteAsync(Address gender, CancellationToken cancellationToken = default);
}