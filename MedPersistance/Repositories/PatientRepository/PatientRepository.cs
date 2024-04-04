using MedDomain.Entities;
using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Patients;

public class PatientRepository : EntityRepositoryBase<int, Patient, MContext>, IPatientRepository
{
    public PatientRepository(MContext dbContext) : base(dbContext) { }

    public IQueryable<Patient> Get(Expression<Func<Patient, bool>>? predicate = default, bool asNoTracking = false) => base.Get(predicate, asNoTracking);

    public new ValueTask<Patient?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default) =>
        base.GetByIdAsync(genderId, asNoTracking, cancellationToken);

    public new ValueTask<Patient> CreateAsync(Patient gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.CreateAsync(gender, saveChanges, cancellationToken);

    public new ValueTask<Patient> UpdateAsync(Patient gender, bool saveChanges = true, CancellationToken cancellationToken = default) =>
        base.UpdateAsync(gender, saveChanges, cancellationToken);

    public ValueTask<Patient> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(genderId, cancellationToken: cancellationToken);
    }

    public ValueTask<Patient> DeleteAsync(Patient gender, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(gender, cancellationToken: cancellationToken);
    }

    public IQueryable<Patient> SelectAll() => base.SelectAll();
}