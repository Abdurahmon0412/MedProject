using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.OblastRepository;

public class OblastRepository : EntityRepositoryBase<int, Oblast, MContext>, IOblastRepository 
{
    public OblastRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Oblast> Get(Expression<Func<Oblast, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Oblast?> GetByIdAsync(int oblastId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(oblastId, asNoTracking, cancellationToken);

    public new ValueTask<Oblast> CreateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(oblast, saveChanges, cancellationToken);

    public new ValueTask<Oblast> UpdateAsync(Oblast oblast, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(oblast, saveChanges, cancellationToken);

    public ValueTask<Oblast> DeleteByIdAsync(int oblastId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(oblastId, cancellationToken: cancellationToken);
    }

    public ValueTask<Oblast> DeleteAsync(Oblast oblast, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(oblast, cancellationToken: cancellationToken);
    }
}