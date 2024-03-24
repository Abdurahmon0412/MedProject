using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.DoctorInfos;

public class DoctorInfoRepository : EntityRepositoryBase<int, DoctorInfo, MContext>, IDoctorInfoRepository
{
    public DoctorInfoRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<DoctorInfo> Get(Expression<Func<DoctorInfo, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<DoctorInfo?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<DoctorInfo> CreateAsync(DoctorInfo gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<DoctorInfo> UpdateAsync(DoctorInfo gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<DoctorInfo> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<DoctorInfo> DeleteAsync(DoctorInfo gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }
}