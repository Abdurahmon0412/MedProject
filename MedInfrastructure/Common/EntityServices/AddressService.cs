using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Addresss;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;
    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public IQueryable<Address> Get(Expression<Func<Address, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _addressRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Address?> GetByIdAsync(int addressId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _addressRepository.GetByIdAsync(addressId, asNoTracking, cancellationToken);
    }

    public ValueTask<Address> CreateAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _addressRepository.CreateAsync(address, saveChanges, cancellationToken);
    }

    public ValueTask<Address> UpdateAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _addressRepository.UpdateAsync(address, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int addressId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _addressRepository.DeleteByIdAsync(addressId, cancellationToken);
    

    public void DeleteAsync(Address address, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _addressRepository.DeleteAsync(address, cancellationToken);
}