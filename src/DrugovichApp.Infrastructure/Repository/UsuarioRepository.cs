using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Infrastructure.Context;
using DrugovichApp.Infrastructure.Repository.Base;

namespace DrugovichApp.Infrastructure.Repository;

public class UsuarioRepository : RepositoryBase<Guid, Usuario>, IUsuarioRepository
{
    public UsuarioRepository(DrugovichAppContext context) : base(context)
    {
    }
}
