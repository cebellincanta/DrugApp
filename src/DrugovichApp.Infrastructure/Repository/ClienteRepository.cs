using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;

namespace DrugovichApp.Infrastructure.Repository;

public class ClienteRepository : RepositoryBase<Guid, Cliente>, IClienteRepository
{
    public ClienteRepository(DrugovichAppContext context) : base(context)
    {
    }
}
