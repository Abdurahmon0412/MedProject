using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Patients;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public IQueryable<Patient> Get(Expression<Func<Patient, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _patientRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Patient?> GetByIdAsync(int patientId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _patientRepository.GetByIdAsync(patientId, asNoTracking, cancellationToken);
    }

    public ValueTask<Patient> CreateAsync(Patient patient, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _patientRepository.CreateAsync(patient, saveChanges, cancellationToken);
    }

    public ValueTask<Patient> UpdateAsync(Patient patient, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _patientRepository.UpdateAsync(patient, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int patientId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _patientRepository.DeleteByIdAsync(patientId, cancellationToken);
    

    public void DeleteAsync(Patient patient, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _patientRepository.DeleteAsync(patient, cancellationToken);
}