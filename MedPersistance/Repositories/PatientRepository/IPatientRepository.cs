using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Patients;

public interface IPatientRepository
{
    IQueryable<Patient> Get(Expression<Func<Patient, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Patient?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Patient> CreateAsync(Patient gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Patient> UpdateAsync(Patient gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Patient> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Patient> DeleteAsync(Patient gender, CancellationToken cancellationToken = default);

    IQueryable<Patient> SelectAll();
}