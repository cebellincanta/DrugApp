using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;

namespace DrugovichApp.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DrugovichAppContext _context;

    public UnitOfWork(DrugovichAppContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
