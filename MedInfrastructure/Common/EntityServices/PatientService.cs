using AutoMapper;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.Dtos.Patient;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Patients;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;
    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _mapper = mapper;
        _patientRepository = patientRepository;
    }

    public IQueryable<PatientForResultDto> Get(Expression<Func<Patient, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _patientRepository.Get(predicate, asNoTracking).Include(i => i.Doctors)
           .Select(item => _mapper.Map<PatientForResultDto>(item));
    }

    public async ValueTask<PatientForResultDto?> GetByIdAsync(int patientId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var patient = await _patientRepository.SelectAll()
              .Where(o => o.Id == patientId)
              .Include(e => e.Doctors)
              .AsNoTracking()
              .FirstOrDefaultAsync();

        if (patient == null)
        {
            throw new Exception("Organization not found or is inactive");
        }

        return _mapper.Map<PatientForResultDto>(patient);
    }

    public async ValueTask<PatientForResultDto> CreateAsync(PatientForCreationDto patient, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var existingPatient = await _patientRepository.Get()
                .Where(a => true)
                //.Where(o => o.Id == patient.id&& o.Pinfl == organization.Pinfl)
                .FirstOrDefaultAsync();

        if (existingPatient != null)
        {
            throw new Exception("Patient already exists");
        }

        var newPatient = _mapper.Map<Patient>(patient);
        newPatient.CreatedDate = DateTime.UtcNow;

        var createdPatient = await _patientRepository.CreateAsync(newPatient, cancellationToken: cancellationToken);

        return _mapper.Map<PatientForResultDto>(createdPatient);
    }

    public async ValueTask<PatientForResultDto> UpdateAsync(PatientForUpdateDto patient, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var newPatient= await _patientRepository.SelectAll()
                .Where(o => o.Id == patient.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (newPatient == null)
        {
            throw new Exception("Patient does not exist!!!");
        }

        //neworganization.ModifiedDate = DateTime.UtcNow;

        var updatedPatient = await _patientRepository.UpdateAsync(newPatient, cancellationToken: cancellationToken);

        return _mapper.Map<PatientForResultDto>(updatedPatient);
    }

    public async ValueTask<PatientForResultDto> DeleteByIdAsync(int patientId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var patient = await _patientRepository.SelectAll()
               .FirstOrDefaultAsync(o => o.Id == patientId);

        if (patient == null)
        {
            throw new Exception("Patient not found");
        }

        return _mapper.Map<PatientForResultDto>(await _patientRepository.DeleteByIdAsync(patientId, cancellationToken));
    }    

    public void DeleteAsync(Patient patient, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _patientRepository.DeleteAsync(patient, cancellationToken);
}