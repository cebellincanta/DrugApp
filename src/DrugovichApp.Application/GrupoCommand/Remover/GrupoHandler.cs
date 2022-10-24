using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.EnumDrug;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Excluir;
public class ClienteHandler : IRequestHandler<ClienteRequest, ClienteDTO>
{
 private readonly IClienteRepository _ClienteRespository;

    public ClienteHandler(IClienteRepository ClienteRespository)
    {
        _ClienteRespository = ClienteRespository;
    }

    public async Task<ClienteDTO> Handle(ClienteRequest request, CancellationToken cancellationToken)
    {
        var erro = new List<ValidacaoErro>();
        var ClienteJaExtiste = await _ClienteRespository.GetFirstAsync(x => x.Id == request.Id);
        if(ClienteJaExtiste is null)
        {
            erro.Add(new ValidacaoErro("Nome", $"O Cliente não existe."));
            throw new NotFoundExcpetionDrug(erro);
        } 

        ClienteJaExtiste.IsActive = StatusData.INACTIVE;
        var result = await _ClienteRespository.Update(ClienteJaExtiste);

        return ClienteMapperDTO.ToDTO(result);
    }
}