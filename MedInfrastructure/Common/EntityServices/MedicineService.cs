using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Medicines;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _medicineRepository;
    public MedicineService(IMedicineRepository medicineRepository)
    {
        _medicineRepository = medicineRepository;
    }

    public IQueryable<Medicine> Get(Expression<Func<Medicine, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _medicineRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Medicine?> GetByIdAsync(int medicineId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _medicineRepository.GetByIdAsync(medicineId, asNoTracking, cancellationToken);
    }

    public ValueTask<Medicine> CreateAsync(Medicine medicine, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _medicineRepository.CreateAsync(medicine, saveChanges, cancellationToken);
    }

    public ValueTask<Medicine> UpdateAsync(Medicine medicine, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _medicineRepository.UpdateAsync(medicine, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int medicineId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _medicineRepository.DeleteByIdAsync(medicineId, cancellationToken);
    

    public void DeleteAsync(Medicine medicine, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _medicineRepository.DeleteAsync(medicine, cancellationToken);
}