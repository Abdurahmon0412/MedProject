using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.StatusRepositories;

public class StatusRepository : EntityRepositoryBase<int, Status, MContext>, IStatusRepository
{
    public StatusRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Status> Get(Expression<Func<Status, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Status?> GetByIdAsync(int roleId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(roleId, asNoTracking, cancellationToken);

    public new ValueTask<Status> CreateAsync(Status role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(role, saveChanges, cancellationToken);

    public new ValueTask<Status> UpdateAsync(Status role, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(role, saveChanges, cancellationToken);

    public ValueTask<Status> DeleteByIdAsync(int roleId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(roleId, cancellationToken: cancellationToken);
    }

    public ValueTask<Status> DeleteAsync(Status role, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(role, cancellationToken: cancellationToken);
    }
}