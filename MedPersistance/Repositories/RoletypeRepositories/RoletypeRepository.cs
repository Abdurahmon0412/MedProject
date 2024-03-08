using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.RoletypeRepositories;

public class RoletypeRepository : EntityRepositoryBase<int, Roletype, MContext>, IRoletypeRepository
{
    public RoletypeRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Roletype> Get(Expression<Func<Roletype, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Roletype?> GetByIdAsync(int roleId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(roleId, asNoTracking, cancellationToken);

    public new ValueTask<Roletype> CreateAsync(Roletype role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(role, saveChanges, cancellationToken);

    public new ValueTask<Roletype> UpdateAsync(Roletype role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(role, saveChanges, cancellationToken);

    public ValueTask<Roletype> DeleteByIdAsync(int roleId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(roleId, cancellationToken: cancellationToken);
    }

    public ValueTask<Roletype> DeleteAsync(Roletype role, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(role, cancellationToken: cancellationToken);
    }
}