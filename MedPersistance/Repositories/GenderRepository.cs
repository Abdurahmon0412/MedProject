using MedPersistance.DataContext;
using MedPersistance.Repositories.Base;
using MedPersistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedPersistance.Repositories;

public class GenderRepository : RepositoryBase<Gender>, IGenderRepository
{
    public GenderRepository(MContext dbContext) : base(dbContext)
    {

    }

    public IQueryable<Gender> GetAllGenderAsync(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Id);

    public async Task<IEnumerable<Gender>> GetByIdsAsync(IEnumerable<long> ids, bool trackChanges) =>
        await FindByCondition(x => ids.Contains(x.Id), trackChanges).ToListAsync();

    public async Task<Gender> GetGenderAsync(long entityId, bool trackChanges) =>
        await FindByConditionWithIncludes(c => c.Id.Equals(entityId), trackChanges).SingleOrDefaultAsync();

    public Gender CreateGender(Gender entity)
    {
        var updatedEntity = SetEntityProperties(entity);
        var createdEntity = Create(entity);
        return createdEntity;
    }

    public IEnumerable<Gender> CreateGenders(IEnumerable<Gender> entities)
    {
        CreateRange(entities);
        return entities;
    }

    public Gender UpdateGender(Gender entity)
    {
        var updatedEntity = Update(entity);
        return updatedEntity;
    }

    public void DeleteGender(Gender entity)
    {
        Delete(entity);
    }

    private Gender SetEntityProperties(Gender entity)
    {
        return entity;
    }
}