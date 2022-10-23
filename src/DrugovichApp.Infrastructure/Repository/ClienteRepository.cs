using System.Linq.Expressions;
using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Repository;

public class ClienteRepository : RepositoryBase<Guid, Cliente>, IClienteRepository
{
    DbSet<Cliente> _dbset;
    public ClienteRepository(DrugovichAppContext context) : base(context)
    {
        _dbSet = context.Set<Cliente>();
    }

    public async Task<Cliente> GetFirstAsync(Expression<Func<Cliente, bool>> predicate) => await _dbSet.Include(x => x.Grupo).Where(predicate).FirstAsync();
}
