using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Interfaces;

public interface IRoleRepository
{
    IQueryable<Role> Get(Expression<Func<Role, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Role?> GetByIdAsync(int roleId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Role> CreateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> UpdateAsync(Role role, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteByIdAsync(int roleId, CancellationToken cancellationToken = default);

    ValueTask<Role> DeleteAsync(Role role, CancellationToken cancellationToken = default);
}