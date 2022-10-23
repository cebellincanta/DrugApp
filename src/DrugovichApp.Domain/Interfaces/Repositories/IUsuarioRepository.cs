using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Repositories.Base;

namespace DrugovichApp.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IRepositoryBase<Guid, Usuario>
{

}