using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.PlasticCards;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class PlasticCardService : IPlasticCardService
{
    private readonly IPlasticCardRepository _plasticCardRepository;
    public PlasticCardService(IPlasticCardRepository plasticCardRepository)
    {
        _plasticCardRepository = plasticCardRepository;
    }

    public IQueryable<PlasticCard> Get(Expression<Func<PlasticCard, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _plasticCardRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<PlasticCard?> GetByIdAsync(int plasticCardId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _plasticCardRepository.GetByIdAsync(plasticCardId, asNoTracking, cancellationToken);
    }

    public ValueTask<PlasticCard> CreateAsync(PlasticCard plasticCard, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _plasticCardRepository.CreateAsync(plasticCard, saveChanges, cancellationToken);
    }

    public ValueTask<PlasticCard> UpdateAsync(PlasticCard plasticCard, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _plasticCardRepository.UpdateAsync(plasticCard, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int plasticCardId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _plasticCardRepository.DeleteByIdAsync(plasticCardId, cancellationToken);
    

    public void DeleteAsync(PlasticCard plasticCard, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _plasticCardRepository.DeleteAsync(plasticCard, cancellationToken);
}