using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;

namespace DrugovichApp.Infrastructure.Repository;

public class GerenteRepository : RepositoryBase<Guid, Gerente>, IGerenteRepository
{
    public GerenteRepository(DrugovichAppContext context) : base(context)
    {
    }
}
