using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;

namespace DrugovichApp.Infrastructure.Repository;

public class GrupoRepository : RepositoryBase<Guid, Grupo>, IGrupoRepository
{
    public GrupoRepository(DrugovichAppContext context) : base(context)
    {
    }
}
