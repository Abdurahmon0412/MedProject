using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.DoctorInfos;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class DoctorInfoService : IDoctorInfoService
{
    private readonly IDoctorInfoRepository _doctorInfoRepository;
    public DoctorInfoService(IDoctorInfoRepository doctorInfoRepository)
    {
        _doctorInfoRepository = doctorInfoRepository;
    }

    public IQueryable<DoctorInfo> Get(Expression<Func<DoctorInfo, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _doctorInfoRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<DoctorInfo?> GetByIdAsync(int doctorInfoId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return _doctorInfoRepository.GetByIdAsync(doctorInfoId, asNoTracking, cancellationToken);
    }

    public ValueTask<DoctorInfo> CreateAsync(DoctorInfo doctorInfo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorInfoRepository.CreateAsync(doctorInfo, saveChanges, cancellationToken);
    }

    public ValueTask<DoctorInfo> UpdateAsync(DoctorInfo doctorInfo, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return _doctorInfoRepository.UpdateAsync(doctorInfo, saveChanges, cancellationToken);
    }

    public void DeleteByIdAsync(int doctorInfoId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => _doctorInfoRepository.DeleteByIdAsync(doctorInfoId, cancellationToken);
    

    public void DeleteAsync(DoctorInfo doctorInfo, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _doctorInfoRepository.DeleteAsync(doctorInfo, cancellationToken);
}