using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Roles;

public class RoleRepository : EntityRepositoryBase<int, Role, MContext>, IRoleRepository
{
    public RoleRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Role?> GetByIdAsync(int roleId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(roleId, asNoTracking, cancellationToken);

    public new ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(role, saveChanges, cancellationToken);

    public new ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(role, saveChanges, cancellationToken);

    public ValueTask<Role> DeleteByIdAsync(int roleId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(roleId, cancellationToken: cancellationToken);
    }

    public ValueTask<Role> DeleteAsync(Role role, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(role, cancellationToken: cancellationToken);
    }
}