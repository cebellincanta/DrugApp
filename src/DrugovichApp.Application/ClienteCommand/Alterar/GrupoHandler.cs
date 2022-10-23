using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Alterar;
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
        if(clienteJaExtiste is null)
        {
            erro.Add(new ValidacaoErro("Nome", $"O Cliente não existe."));
            throw new NotFoundExcpetionDrug(erro);
        } 

        clienteJaExtiste.Nome = request.Nome;
        clienteJaExtiste.Cnpj = request.Cnpj;
        clienteJaExtiste.DataFundacao = request.DataFundacao;
        clienteJaExtiste.GrupoId = request.GrupoId;
        var result = await _clienteRespository.Update(clienteJaExtiste);

        return ClienteMapperDTO.ToDTO(result);
    }
}