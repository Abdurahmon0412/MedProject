using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.RoletypeRepositories;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class RoletypeService : IRoletypeService
{
    private readonly IRoletypeRepository _roletypeRepository;
    public RoletypeService(IRoletypeRepository roletypeRepository)
    {
        _roletypeRepository = roletypeRepository;
    }

    public IQueryable<Roletype> Get(Expression<Func<Roletype, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _roletypeRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Roletype?> GetByIdAsync(int roletypeId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _roletypeRepository.GetByIdAsync(roletypeId, asNoTracking, cancellationToken);
    }

    public ValueTask<Roletype> CreateAsync(Roletype roletype, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _roletypeRepository.CreateAsync(roletype, saveChanges, cancellationToken);
    }

    public ValueTask<Roletype> UpdateAsync(Roletype roletype, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _roletypeRepository.UpdateAsync(roletype, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int roletypeId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _roletypeRepository.DeleteByIdAsync(roletypeId, cancellationToken);
    

    public void DeleteAsync(Roletype roletype, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _roletypeRepository.DeleteAsync(roletype, cancellationToken);
}