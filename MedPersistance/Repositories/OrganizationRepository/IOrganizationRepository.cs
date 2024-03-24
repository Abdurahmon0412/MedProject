using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.OrganizationRepository;

public interface IOrganizationRepository
{
    IQueryable<Organization> Get(Expression<Func<Organization, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Organization?> GetByIdAsync(int organizationId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Organization> CreateAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Organization> UpdateAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Organization> DeleteByIdAsync(int organizationId, CancellationToken cancellationToken = default);

    ValueTask<Organization> DeleteAsync(Organization organization, CancellationToken cancellationToken = default);

    IQueryable<Organization> SelectAll();
}
