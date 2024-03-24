using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.DoctorInfos;

public interface IDoctorInfoRepository
{
    IQueryable<DoctorInfo> Get(Expression<Func<DoctorInfo, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<DoctorInfo?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<DoctorInfo> CreateAsync(DoctorInfo gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<DoctorInfo> UpdateAsync(DoctorInfo gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<DoctorInfo> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<DoctorInfo> DeleteAsync(DoctorInfo gender, CancellationToken cancellationToken = default);
}