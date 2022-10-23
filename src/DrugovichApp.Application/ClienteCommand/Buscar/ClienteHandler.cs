using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Buscar;
public class ClienteHandler : IRequestHandler<ClienteRequest, ClienteDTO>
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteHandler(IClienteRepository clienteRespository)
    {
        _clienteRepository = clienteRespository;
    }

    public async Task<ClienteDTO> Handle(ClienteRequest request, CancellationToken cancellationToken)
    {
        var erro = new List<ValidacaoErro>();
        var clienteJaExtiste = await _clienteRepository.GetFirstAsync(x => x.Cnpj == request.Cnpj);
        if(clienteJaExtiste is null)
        {
            erro.Add(new ValidacaoErro("Cnpj", $"O Cliente com CNPJ {request.Cnpj} não existe."));
            throw new NotFoundExcpetionDrug(erro);
        } 

        return ClienteMapperDTO.ToDTO(clienteJaExtiste);
    }
}