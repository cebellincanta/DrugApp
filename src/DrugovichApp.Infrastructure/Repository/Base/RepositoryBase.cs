using System.Linq.Expressions;
using DrugovichApp.Domain.Entities.Base;
using DrugovichApp.Domain.Interfaces.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Repository.Base;

public class RepositoryBase<TId, TEntity> : IRepositoryBase<TId, TEntity> where TId : struct where TEntity : EntityBase<TId>
{
    protected DbContext _context;
    protected DbSet<TEntity> _dbSet;

    public RepositoryBase(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity obj)
    {
       await _dbSet.AddAsync(obj);
       return obj;
    }

    public void Delete(TEntity obj)
    {
        _dbSet.Remove(obj);
    }

    public async Task<bool> DeleteLogic(TId id)
    {
        var o = await GetFirstAsync(x => x.Id.Equals(id));
        if(o == null) return false;
        o.IsActive = false;
        await Update(o);
        return true;
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAsync()=> await _dbSet.ToListAsync();

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.Where(predicate).FirstAsync();

    public Task<TEntity> Update(TEntity obj)
    {
        _dbSet.Update(obj);
        return Task.FromResult(obj);
    }
}
