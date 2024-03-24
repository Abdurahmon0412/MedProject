using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.DoctorPlaces;

public interface IDoctorPlaceRepository
{
    IQueryable<DoctorPlace> Get(Expression<Func<DoctorPlace, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<DoctorPlace?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<DoctorPlace> CreateAsync(DoctorPlace gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<DoctorPlace> UpdateAsync(DoctorPlace gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<DoctorPlace> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<DoctorPlace> DeleteAsync(DoctorPlace gender, CancellationToken cancellationToken = default);
}