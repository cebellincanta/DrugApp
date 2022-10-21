using DrugovichApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Context;

public class DrugovichAppContext : DbContext
{
    public DrugovichAppContext(DbContextOptionsBuilder options) => options.UseInMemoryDatabase(databaseName: "DrugovichDB");

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<Gerente> Gerente { get; set; }
    public DbSet<Grupo> Grupo { get; set; }

}
