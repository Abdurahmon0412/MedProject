using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.DoctorPlaces;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DoctorPlaceService : IDoctorPlaceService
{
    private readonly IDoctorPlaceRepository _doctorPlaceRepository;
    public DoctorPlaceService(IDoctorPlaceRepository doctorPlaceRepository)
    {
        _doctorPlaceRepository = doctorPlaceRepository;
    }

    public IQueryable<DoctorPlace> Get(Expression<Func<DoctorPlace, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _doctorPlaceRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<DoctorPlace?> GetByIdAsync(int doctorPlaceId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _doctorPlaceRepository.GetByIdAsync(doctorPlaceId, asNoTracking, cancellationToken);
    }

    public ValueTask<DoctorPlace> CreateAsync(DoctorPlace doctorPlace, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorPlaceRepository.CreateAsync(doctorPlace, saveChanges, cancellationToken);
    }

    public ValueTask<DoctorPlace> UpdateAsync(DoctorPlace doctorPlace, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorPlaceRepository.UpdateAsync(doctorPlace, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int doctorPlaceId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _doctorPlaceRepository.DeleteByIdAsync(doctorPlaceId, cancellationToken);
    

    public void DeleteAsync(DoctorPlace doctorPlace, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _doctorPlaceRepository.DeleteAsync(doctorPlace, cancellationToken);
}