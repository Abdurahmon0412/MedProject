using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Doctors;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    public DoctorService(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public IQueryable<Doctor> Get(Expression<Func<Doctor, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _doctorRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Doctor?> GetByIdAsync(int doctorId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _doctorRepository.GetByIdAsync(doctorId, asNoTracking, cancellationToken);
    }

    public ValueTask<Doctor> CreateAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorRepository.CreateAsync(doctor, saveChanges, cancellationToken);
    }

    public ValueTask<Doctor> UpdateAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorRepository.UpdateAsync(doctor, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int doctorId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _doctorRepository.DeleteByIdAsync(doctorId, cancellationToken);
    

    public void DeleteAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _doctorRepository.DeleteAsync(doctor, cancellationToken);
}