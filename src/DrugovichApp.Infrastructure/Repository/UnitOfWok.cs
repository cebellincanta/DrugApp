using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DrugovichApp.Infrastructure.Repository;

public class UnitOfWork :IAsyncActionFilter, IUnitOfWork
{
    private readonly DrugovichAppContext _context;

    public UnitOfWork(DrugovichAppContext context)
    {
        _context = context;
    }

     public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
        if (result.Exception == null || result.ExceptionHandled)
        {
            await _context.SaveChangesAsync();
        }
    }
}
