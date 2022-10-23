using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Entities;

namespace DrugovichApp.Domain.Mapper;

public class UsuarioMapperDTO
{
    public static UsuarioDTO ToDTO(Usuario usuario)
    {
        return new UsuarioDTO
        {
            Id = usuario.Id,
            IsActive = usuario.IsActive,
            NomeUsuario = usuario.NomeUsuario,
            Gerente =  new GerenteDTO
            {
                Nome = usuario.Gerente.Nome,
                Email = usuario.Gerente.Email,
                Nivel = usuario.Gerente.Nivel
            }
        };
    }
}