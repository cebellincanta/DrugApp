using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.EnumDrug;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Listar;
public class ClienteHandler : IRequestHandler<ClienteRequest, List<ClienteDTO>>
{
    private readonly IClienteRepository _ClienteRespository;

    public ClienteHandler(IClienteRepository ClienteRespository)
    {
        _ClienteRespository = ClienteRespository;
    }

    async Task<List<ClienteDTO>> IRequestHandler<ClienteRequest, List<ClienteDTO>>.Handle(ClienteRequest request, CancellationToken cancellationToken)
    {
        var Clientes = await _ClienteRespository.GetAsync(w => w.IsActive == StatusData.ACTIVE);
        return Clientes.Select(Cliente => ClienteMapperDTO.ToDTO(Cliente)).ToList();
    }
}