using MedDomain.Entities;

namespace MedPersistance.Repositories.Interfaces;

public interface IGenderRepository
{
    IQueryable<Gender> GetAllGenderAsync(bool trackChanges);
    Task<Gender> GetGenderAsync(long entityId, bool trackChanges);
    Gender CreateGender(Gender entity);
    Gender UpdateGender(Gender entity);
    Task<IEnumerable<Gender>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges);
    void DeleteGender(Gender entity);
    IEnumerable<Gender> CreateGenders(IEnumerable<Gender> entities);
}