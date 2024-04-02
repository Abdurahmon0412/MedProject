using MedDomain.Entities;
using System.Linq.Expressions;

namespace MedPersistance.Repositories.Departments;

public interface IDepartmentRepository
{
    IQueryable<Department> Get(Expression<Func<Department, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<Department?> GetByIdAsync(int genderId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Department> CreateAsync(Department gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Department> UpdateAsync(Department gender, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Department> DeleteByIdAsync(int genderId, CancellationToken cancellationToken = default);

    ValueTask<Department> DeleteAsync(Department gender, CancellationToken cancellationToken = default);

    IQueryable<Department> SelectAll();
}