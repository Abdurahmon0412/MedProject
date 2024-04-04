using AutoMapper;
using MedApplication.Common.Dtos.Department;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public IQueryable<DepartmentForResultDto> Get(Expression<Func<Department, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _departmentRepository.Get(predicate, asNoTracking).Include(d => d.Doctors)
            .Select(item => _mapper.Map<DepartmentForResultDto>(item));
    }

    public async ValueTask<DepartmentForResultDto?> GetByIdAsync(int departmentId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var department = await _departmentRepository.SelectAll()
            .Where(d => d.Id == departmentId)
            .Include(d => d.Doctors).AsNoTracking().FirstOrDefaultAsync() ?? throw new Exception("Department Not found!!!");
        return _mapper.Map<DepartmentForResultDto>(department);
    }

    public async ValueTask<DepartmentForResultDto> CreateAsync(DepartmentForCreationDto department, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        // department = await _departmentRepository.SelectAll()
        //return _departmentRepository.CreateAsync(department, saveChanges, cancellationToken);

        var existingDepartment = await _departmentRepository.Get()
                .Where(o => o.ShortName == department.ShortName)
                .FirstOrDefaultAsync();

        if (existingDepartment != null)
        {
            throw new Exception("Department already exists");
        }

        var newDepartment = _mapper.Map<Department>(department);
        newDepartment.CreatedDate = DateTime.UtcNow;

        var createdDepartment = await _departmentRepository.CreateAsync(newDepartment, cancellationToken: cancellationToken);

        return _mapper.Map<DepartmentForResultDto>(createdDepartment);
    }

    public async ValueTask<DepartmentForResultDto> UpdateAsync(DepartmentForUpdateDto department, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var newdepartment = await _departmentRepository.SelectAll()
                .Where(o => true)//o.Id == department.Id)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (newdepartment == null)
        {
            throw new Exception("Department does not exist!!!");
        }

        ////neworganization.ModifiedDate = DateTime.UtcNow;

        var updatedDepartment = await _departmentRepository.UpdateAsync(newdepartment, cancellationToken: cancellationToken);

        return _mapper.Map<DepartmentForResultDto>(updatedDepartment);
    }

    public async ValueTask<DepartmentForResultDto> DeleteByIdAsync(int departmentId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var department = await _departmentRepository.SelectAll()
                .FirstOrDefaultAsync(o => o.Id == departmentId);

        if (department == null)
        {
            throw new Exception("Organization not found");
        }

        return _mapper.Map<DepartmentForResultDto>(await _departmentRepository.DeleteByIdAsync(departmentId, cancellationToken));
    }
    
    public void DeleteAsync(Department department, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _departmentRepository.DeleteAsync(department, cancellationToken);
}