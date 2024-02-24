using System.Linq.Expressions;

namespace MedPersistance.Repositories.Base
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindAllWithIncludes(bool trackChanges, params string[] includes);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        IQueryable<T> FindByConditionWithIncludes(Expression<Func<T, bool>> expression, bool trackChanges, params string[] includes);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}