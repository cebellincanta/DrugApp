using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Entities;

namespace DrugovichApp.Domain.Mapper;

public class ClienteMapperDTO
{
    public static ClienteDTO ToDTO(Cliente cliente)
    {
        return new ClienteDTO
        {
            Id = cliente.Id,
            IsActive = cliente.IsActive,
            Nome = cliente.Nome,
            DataFundacao = cliente.DataFundacao,
            Cnpj = cliente.Cnpj,
            Grupo = new GrupoDTO 
                    {
                        Nome = cliente.Grupo.Nome
                    }
        };
    }
}