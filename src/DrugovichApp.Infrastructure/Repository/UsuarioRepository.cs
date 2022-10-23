using System.Linq.Expressions;
using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Repository;

public class UsuarioRepository : RepositoryBase<Guid, Usuario>, IUsuarioRepository
{
     DbSet<Usuario> _dbset;
    public UsuarioRepository(DrugovichAppContext context) : base(context)
    {
        _dbSet = context.Set<Usuario>();
    }

    public async Task<Usuario> GetFirstAsync(Expression<Func<Usuario, bool>> predicate) => await _dbSet.Include(x => x.Gerente).Where(predicate).FirstAsync();
}
