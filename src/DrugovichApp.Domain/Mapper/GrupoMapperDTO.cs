using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Entities;

namespace DrugovichApp.Domain.Mapper;

public class GrupoMapperDTO
{
    public static GrupoDTO ToDTO(Grupo grupo)
    {
        return new GrupoDTO
        {
            Id = grupo.Id,
            IsActive = grupo.IsActive,
            Nome = grupo.Nome
        };
    }
}