
using System.Linq.Expressions;
using DrugovichApp.Domain.Entities.Base;

namespace DrugovichApp.Domain.Interfaces.Repositories.Base;

public interface IRepositoryBase<TId, TEntity> where TId : struct where TEntity : EntityBase<TId>
{
    Task<TEntity> AddAsync(TEntity obj); 
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate); 
    Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate); 
    Task<IEnumerable<TEntity>> GetAsync(); 
    Task<TEntity> Update(TEntity obj);
    Task<bool> DeleteLogic(TId id);
    void Delete(TEntity obj);


}
