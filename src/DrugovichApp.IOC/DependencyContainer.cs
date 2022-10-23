using System.Reflection;
using DrugovichApp.Application.MediatRService;
using DrugovichApp.Domain.Interfaces.Mediator;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Repository;
using DrugovichApp.IOC.Configuration;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrugovichApp.IOC;

public static class DependencyContainer
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        RegisterContext(services, configuration);
        Configure(services);
        RegisterMediator(services);
        RegisterRepository(services);
    }

    public static void RegisterContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDBContextConfiguration(configuration);
    }

    public static void Configure(IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavivior<,>));
        services.AddValidatorsFromAssembly(typeof(ValidationBehavivior<,>).Assembly);
        services.AddMediatR(typeof(MediatRHandler<,>).GetTypeInfo().Assembly);
    }

    public static void RegisterMediator(IServiceCollection services)
    {
        services.AddScoped(typeof(IMediatorHandler<,>), typeof(MediatRHandler<,>));
    }

    public static void RegisterRepository(IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IGrupoRepository, GrupoRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
    }
} 