using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.EnumDrug;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Excluir;
public class GrupoHandler : IRequestHandler<GrupoRequest, GrupoDTO>
{
 private readonly IGrupoRepository _grupoRespository;

    public GrupoHandler(IGrupoRepository grupoRespository)
    {
        _grupoRespository = grupoRespository;
    }

    public async Task<GrupoDTO> Handle(GrupoRequest request, CancellationToken cancellationToken)
    {
        var erro = new List<ValidacaoErro>();
        var grupoJaExtiste = await _grupoRespository.GetFirstAsync(x => x.Id == request.Id);
        if(grupoJaExtiste is null)
        {
            erro.Add(new ValidacaoErro("Nome", $"O grupo não existe."));
            throw new NotFoundExcpetionDrug(erro);
        } 

        grupoJaExtiste.IsActive = StatusData.INACTIVE;
        var result = await _grupoRespository.Update(grupoJaExtiste);

        return GrupoMapperDTO.ToDTO(result);
    }
}