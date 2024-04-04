using AutoMapper;
using MedApplication.Common.Dtos;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Examinations;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class ExaminationService : IExaminationService
{
    private readonly IExaminationRepository _examinationRepository;
    private readonly IMapper _mapper;
    public ExaminationService(IExaminationRepository examinationRepository, IMapper mapper)
    {
        _mapper = mapper;
        _examinationRepository = examinationRepository;
    }

    public IQueryable<ExaminationForResultDto> Get(Expression<Func<Examination, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _examinationRepository.Get(predicate, asNoTracking).Include(o => o.Patients)
           .Select(item => _mapper.Map<ExaminationForResultDto>(item));
    }

    public async ValueTask<ExaminationForResultDto?> GetByIdAsync(int examinationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var organization = await _examinationRepository.SelectAll()
               .Where(o => o.Id == examinationId)
               .Include(e => e.Patients)
               .AsNoTracking()
               .FirstOrDefaultAsync();

        if (organization == null)
        {
            throw new Exception("Organization not found or is inactive");
        }

        return _mapper.Map<ExaminationForResultDto>(organization);
    }

    public async ValueTask<ExaminationForResultDto> CreateAsync(ExaminationForCreationDto examination, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        //return _organizationRepository.CreateAsync(organization, saveChanges, cancellationToken);

        var existingExamination = await _examinationRepository.Get()
                .Where(o => o.Id == examination.Id)
                .FirstOrDefaultAsync();

        if (existingExamination != null)
        {
            throw new Exception("Examination already exists");
        }

        var newExamination = _mapper.Map<Examination>(examination);
        newExamination.CreatedDate = DateTime.UtcNow;

        var createdExmination = await _examinationRepository.CreateAsync(newExamination, cancellationToken: cancellationToken);

        return _mapper.Map<ExaminationForResultDto>(createdExmination);
    }

    public async ValueTask<ExaminationForResultDto> UpdateAsync(ExaminationForUpdateDto examination, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var newExamination = await _examinationRepository.SelectAll()
                .Where(o => o.Id == examination.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (newExamination == null)
        {
            throw new Exception("Examination does not exist!!!");
        }

        newExamination.ModifiedDate = DateTime.UtcNow;

        var updatedExamination = await _examinationRepository.UpdateAsync(newExamination, cancellationToken: cancellationToken);

        return _mapper.Map<ExaminationForResultDto>(updatedExamination);
    }

    public async ValueTask<ExaminationForResultDto> DeleteByIdAsync(int examinationId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var examination = await _examinationRepository.SelectAll()
                .FirstOrDefaultAsync(o => o.Id == examinationId);

        if (examination == null)
        {
            throw new Exception("Examination not found");
        }

        return _mapper.Map<ExaminationForResultDto>(await _examinationRepository.DeleteByIdAsync(examinationId, cancellationToken));
    }
    

    public void DeleteAsync(Examination examination, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _examinationRepository.DeleteAsync(examination, cancellationToken);
}