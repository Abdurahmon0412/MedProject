using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.DoctorPlaces;

public class DoctorPlaceRepository : EntityRepositoryBase<int, DoctorPlace, MContext>, IDoctorPlaceRepository
{
    public DoctorPlaceRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<DoctorPlace> Get(Expression<Func<DoctorPlace, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<DoctorPlace?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<DoctorPlace> CreateAsync(DoctorPlace gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<DoctorPlace> UpdateAsync(DoctorPlace gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<DoctorPlace> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<DoctorPlace> DeleteAsync(DoctorPlace gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }
}