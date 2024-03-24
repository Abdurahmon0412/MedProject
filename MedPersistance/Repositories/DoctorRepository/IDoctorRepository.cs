using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Doctors;

public interface IDoctorRepository
{
    IQueryable<Doctor> Get(Expression<Func<Doctor, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Doctor?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Doctor> CreateAsync(Doctor gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Doctor> UpdateAsync(Doctor gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Doctor> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Doctor> DeleteAsync(Doctor gender, CancellationToken cancellationToken = default);
}