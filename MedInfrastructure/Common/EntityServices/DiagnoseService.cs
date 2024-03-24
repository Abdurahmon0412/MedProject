using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Diagnoses;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DiagnoseService : IDiagnoseService
{
    private readonly IDiagnoseRepository _diagnoseRepository;
    public DiagnoseService(IDiagnoseRepository diagnoseRepository)
    {
        _diagnoseRepository = diagnoseRepository;
    }

    public IQueryable<Diagnose> Get(Expression<Func<Diagnose, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _diagnoseRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Diagnose?> GetByIdAsync(int diagnoseId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _diagnoseRepository.GetByIdAsync(diagnoseId, asNoTracking, cancellationToken);
    }

    public ValueTask<Diagnose> CreateAsync(Diagnose diagnose, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _diagnoseRepository.CreateAsync(diagnose, saveChanges, cancellationToken);
    }

    public ValueTask<Diagnose> UpdateAsync(Diagnose diagnose, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _diagnoseRepository.UpdateAsync(diagnose, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int diagnoseId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _diagnoseRepository.DeleteByIdAsync(diagnoseId, cancellationToken);
    

    public void DeleteAsync(Diagnose diagnose, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _diagnoseRepository.DeleteAsync(diagnose, cancellationToken);
}