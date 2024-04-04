using AutoMapper;
using MedApplication.Common.Dtos.Doctor;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Doctors;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IMapper _mapper;
    public DoctorService(IDoctorRepository doctorRepository, IMapper mapper)
    {
        _mapper = mapper;
        _doctorRepository = doctorRepository;
    }

    public IQueryable<DoctorForResultDto> Get(Expression<Func<Doctor, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _doctorRepository.Get(predicate, asNoTracking).Select(item => _mapper.Map<DoctorForResultDto>(item));
    }

    public async ValueTask<DoctorForResultDto?> GetByIdAsync(int doctorId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var doctor = await _doctorRepository.SelectAll()
               .Where(o => o.Id == doctorId)
               .AsNoTracking()
               .FirstOrDefaultAsync();
        if (doctor == null)
            throw new Exception("Doctor not found or is inactive");

        return _mapper.Map<DoctorForResultDto>(doctor);
    }

    public async ValueTask<DoctorForResultDto> CreateAsync(DoctorForCreationDto doctor, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        //return _organizationRepository.CreateAsync(organization, saveChanges, cancellationToken);

        var existingDoctor = await _doctorRepository.Get()
                //.Where(o => o.DepartmentId == doctor. && o.Pinfl == organization.Pinfl)
                .Where(d => true)
                .FirstOrDefaultAsync();

        if (existingDoctor != null)
        {
            throw new Exception("Organization already exists");
        }

        var newOrganization = _mapper.Map<Doctor>(doctor);

        var createdDoctor = await _doctorRepository.CreateAsync(newOrganization, saveChanges, cancellationToken: cancellationToken);

        return _mapper.Map<DoctorForResultDto>(createdDoctor);
    }

    public async ValueTask<DoctorForResultDto> UpdateAsync(DoctorForUpdateDto doctor, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var newDoctor = await _doctorRepository.SelectAll()
               .Where(o => o.Id == doctor.Id)
               .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (newDoctor == null)
        {
            throw new Exception("Organization does not exist!!!");
        }

        //neworganization.ModifiedDate = DateTime.UtcNow;

        var updatedDoctor = await _doctorRepository.UpdateAsync(newDoctor, cancellationToken: cancellationToken);

        return _mapper.Map<DoctorForResultDto>(updatedDoctor);
    }

    public async ValueTask<DoctorForResultDto> DeleteByIdAsync(int doctorId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var doctor = _doctorRepository.SelectAll()
                .FirstOrDefaultAsync(o => o.Id == doctorId);

        if (doctor == null)
            throw new Exception("Organization not found");

        return _mapper.Map<DoctorForResultDto>(await _doctorRepository.DeleteByIdAsync(doctorId, cancellationToken));
    }
    
    public void DeleteAsync(Doctor doctor, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _doctorRepository.DeleteAsync(doctor, cancellationToken);
}