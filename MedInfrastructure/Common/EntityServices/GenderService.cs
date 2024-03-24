using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Genders;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class GenderService : IGenderService
{
    private readonly IGenderRepository _genderRepository;
    public GenderService(IGenderRepository genderRepository)
    {
        _genderRepository = genderRepository;
    }

    public IQueryable<Gender> Get(Expression<Func<Gender, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _genderRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Gender?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _genderRepository.GetByIdAsync(genderId, asNoTracking, cancellationToken);
    }

    public ValueTask<Gender> CreateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _genderRepository.CreateAsync(gender, saveChanges, cancellationToken);
    }

    public ValueTask<Gender> UpdateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _genderRepository.UpdateAsync(gender, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int genderId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _genderRepository.DeleteByIdAsync(genderId, cancellationToken);
    

    public void DeleteAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _genderRepository.DeleteAsync(gender, cancellationToken);
}