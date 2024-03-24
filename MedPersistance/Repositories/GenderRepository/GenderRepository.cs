using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Genders;

public class GenderRepository : EntityRepositoryBase<int, Gender, MContext>, IGenderRepository
{
    public GenderRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Gender> Get(Expression<Func<Gender, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Gender?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<Gender> CreateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<Gender> UpdateAsync(Gender gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<Gender> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<Gender> DeleteAsync(Gender gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }
}