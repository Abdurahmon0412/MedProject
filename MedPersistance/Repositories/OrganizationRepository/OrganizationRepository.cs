using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.OrganizationRepository;

public class OrganizationRepository : EntityRepositoryBase<int, Organization, MContext>, IOrganizationRepository
{
    public OrganizationRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Organization> Get(Expression<Func<Organization, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Organization?> GetByIdAsync(int organizationId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(organizationId, asNoTracking, cancellationToken);

    public new ValueTask<Organization> CreateAsync(Organization region, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(region, saveChanges, cancellationToken);

    public new ValueTask<Organization> UpdateAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(organization, saveChanges, cancellationToken);

    public ValueTask<Organization> DeleteByIdAsync(int organizationId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(organizationId, cancellationToken: cancellationToken);
    }

    public ValueTask<Organization> DeleteAsync(Organization organization, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(organization, cancellationToken: cancellationToken);
    }

    public IQueryable<Organization> SelectAll() => base.SelectAll();
}