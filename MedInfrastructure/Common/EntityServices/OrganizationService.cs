using AutoMapper;
using MedApplication.Common.Dtos.Organization;
using MedApplication.Common.EntityServices;
using MedDomain.Entities;
using MedPersistance.Repositories.OrganizationRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedInfrastructure.Common.EntityServices;

public class OrganizationService : IOrganizationService
{
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IMapper _mapper;
    public OrganizationService(IOrganizationRepository organizationRepository, IMapper mapper)
    {
        _organizationRepository = organizationRepository;
        _mapper = mapper;
    }

    public IQueryable<Organization> Get(Expression<Func<Organization, bool>>? predicate = default, bool asNoTracking = false)
    {
        return _organizationRepository.Get(predicate, asNoTracking).Include(o => o.UserModules);
    }

    public async ValueTask<OrganizationForResultDto?> GetByIdAsync(int organizationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var organization = await _organizationRepository.SelectAll()
               .Where(o => o.Id == organizationId)
               .Include(e => e.UserModules)
               .AsNoTracking()
               .FirstOrDefaultAsync();

        if (organization == null)
        {
            throw new Exception("Organization not found or is inactive");
        }

        return _mapper.Map<OrganizationForResultDto>(organization);
    }

    public async ValueTask<OrganizationForResultDto> CreateAsync(OrganizationForCreationDto organization, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        //return _organizationRepository.CreateAsync(organization, saveChanges, cancellationToken);

        var existingOrganization = await _organizationRepository.Get()
                .Where(o => o.ShortName == organization.ShortName && o.Pinfl == organization.Pinfl)
                .FirstOrDefaultAsync();

        if (existingOrganization != null)
        {
            throw new Exception("Organization already exists");
        }

        var newOrganization = _mapper.Map<Organization>(organization);
        newOrganization.CreatedDate = DateTime.UtcNow;

        var createdOrganization = await _organizationRepository.CreateAsync(newOrganization, cancellationToken: cancellationToken);

        return _mapper.Map<OrganizationForResultDto>(createdOrganization);
    }

    public async ValueTask<OrganizationForResultDto> UpdateAsync(OrganizationForUpdateDto organization, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var neworganization = await _organizationRepository.SelectAll()
                .Where(o => o.Id == organization.Id)
                .FirstOrDefaultAsync();

        if (neworganization == null)
        {
            throw new Exception("Organization does not exist or is inactive");
        }

        neworganization.ModifiedDate = DateTime.UtcNow;
        
        var updatedOrganization = await _organizationRepository.UpdateAsync(neworganization);

        return _mapper.Map<OrganizationForResultDto>(updatedOrganization);
    }

    public async ValueTask<OrganizationForResultDto> DeleteByIdAsync(int organizationId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var organization = await _organizationRepository.SelectAll()
                .FirstOrDefaultAsync(o => o.Id == organizationId);

        if (organization == null)
        {
            throw new Exception("Organization not found");
        }
        
        return _mapper.Map<OrganizationForResultDto>( await _organizationRepository.DeleteByIdAsync(organizationId, cancellationToken));
    }    

    public void DeleteAsync(Organization organization, bool saveChanges = true, CancellationToken cancellationToken = default) 
        => _organizationRepository.DeleteAsync(organization, cancellationToken);
}