using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Adicionar;
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
        var grupoJaExtiste = await _grupoRespository.GetFirstAsync(x => x.Nome == request.Nome);
        if(grupoJaExtiste is not null)
        {
            erro.Add(new ValidacaoErro("Nome", $"O grupo {grupoJaExtiste.Nome} já existe."));
            throw new ValidationExceptionDrug(erro);
        } 

        var grupo = GrupoMapper.ToGrupo(request);
        var result = await _grupoRespository.AddAsync(grupo);

        return GrupoMapperDTO.ToDTO(result);
    }
}