using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Adicionar;
public class ClienteHandler : IRequestHandler<ClienteRequest, ClienteDTO>
{
    private readonly IClienteRepository _clienteRespository;

    public ClienteHandler(IClienteRepository clienteRespository)
    {
        _clienteRespository = clienteRespository;
    }

    public async Task<ClienteDTO> Handle(ClienteRequest request, CancellationToken cancellationToken)
    {
        var erro = new List<ValidacaoErro>();
        var clienteJaExtiste = await _clienteRespository.GetFirstAsync(x => x.Cnpj == request.Cnpj);
        if(clienteJaExtiste is not null)
        {
            erro.Add(new ValidacaoErro("Nome", $"O Cliente {clienteJaExtiste.Nome} já existe."));
            throw new ValidationExceptionDrug(erro);
        } 

        var grupo = ClienteMapper.ToCliente(request);
        var result = await _clienteRespository.AddAsync(grupo);

        return ClienteMapperDTO.ToDTO(result);
    }
}