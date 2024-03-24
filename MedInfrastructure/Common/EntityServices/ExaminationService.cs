using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Examinations;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class ExaminationService : IExaminationService
{
    private readonly IExaminationRepository _examinationRepository;
    public ExaminationService(IExaminationRepository examinationRepository)
    {
        _examinationRepository = examinationRepository;
    }

    public IQueryable<Examination> Get(Expression<Func<Examination, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _examinationRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Examination?> GetByIdAsync(int examinationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _examinationRepository.GetByIdAsync(examinationId, asNoTracking, cancellationToken);
    }

    public ValueTask<Examination> CreateAsync(Examination examination, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _examinationRepository.CreateAsync(examination, saveChanges, cancellationToken);
    }

    public ValueTask<Examination> UpdateAsync(Examination examination, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _examinationRepository.UpdateAsync(examination, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int examinationId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _examinationRepository.DeleteByIdAsync(examinationId, cancellationToken);
    

    public void DeleteAsync(Examination examination, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _examinationRepository.DeleteAsync(examination, cancellationToken);
}