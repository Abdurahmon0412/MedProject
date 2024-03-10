using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.OrganizationRepository;
using MedPersistance.Repositories.User;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    public OrganizationService(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }

    public IQueryable<Organization> Get(Expression<Func<Organization, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _organizationRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Organization?> GetByIdAsync(int organizationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _organizationRepository.GetByIdAsync(organizationId, asNoTracking, cancellationToken);
    }

    public ValueTask<Organization> CreateAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _organizationRepository.CreateAsync(organization, saveChanges, cancellationToken);
    }

    public ValueTask<Organization> UpdateAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _organizationRepository.UpdateAsync(organization, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int organizationId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _organizationRepository.DeleteByIdAsync(organizationId, cancellationToken);
    

    public void DeleteAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _organizationRepository.DeleteAsync(organization, cancellationToken);
}
