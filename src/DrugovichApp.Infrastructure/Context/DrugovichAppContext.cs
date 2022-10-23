using DrugovichApp.Infrastructure.Extensions;
using DrugovichApp.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Context;

public class DrugovichAppContext : DbContext
{
    public DrugovichAppContext(DbContextOptions<DrugovichAppContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.AddConfiguration(new ClienteMapping());
        modelBuilder.AddConfiguration(new GerenteMapping());
        modelBuilder.AddConfiguration(new GrupoMapping());
        modelBuilder.AddConfiguration(new UsuarioMapping());
    }

}
