using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using System.Linq.Expressions;
namespace MedPersistance.Repositories.User;

public class UserModuleRepository : EntityRepositoryBase<long, UserModule, MContext>, IUserModuleRepository
{

    public UserModuleRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<UserModule> Get(Expression<Func<UserModule, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<UserModule?> GetByIdAsync(long userId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(userId, asNoTracking, cancellationToken);

    public new ValueTask<UserModule> CreateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(user, saveChanges, cancellationToken);

    public new ValueTask<UserModule> UpdateAsync(UserModule user, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(user, saveChanges, cancellationToken);

    public ValueTask<UserModule> DeleteByIdAsync(long userId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(userId, cancellationToken: cancellationToken);
    }

    public ValueTask<UserModule> DeleteAsync(UserModule user, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(user, cancellationToken: cancellationToken);
    }
}