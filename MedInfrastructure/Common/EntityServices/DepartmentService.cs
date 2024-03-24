using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Departments;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public IQueryable<Department> Get(Expression<Func<Department, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _departmentRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<Department?> GetByIdAsync(int departmentId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _departmentRepository.GetByIdAsync(departmentId, asNoTracking, cancellationToken);
    }

    public ValueTask<Department> CreateAsync(Department department, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _departmentRepository.CreateAsync(department, saveChanges, cancellationToken);
    }

    public ValueTask<Department> UpdateAsync(Department department, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _departmentRepository.UpdateAsync(department, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int departmentId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _departmentRepository.DeleteByIdAsync(departmentId, cancellationToken);
    

    public void DeleteAsync(Department department, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _departmentRepository.DeleteAsync(department, cancellationToken);
}