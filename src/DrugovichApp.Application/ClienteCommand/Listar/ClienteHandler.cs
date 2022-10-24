using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.EnumDrug;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Listar;
public class GrupoHandler : IRequestHandler<GrupoRequest, List<GrupoDTO>>
{
    private readonly IGrupoRepository _grupoRespository;

    public GrupoHandler(IGrupoRepository grupoRespository)
    {
        _grupoRespository = grupoRespository;
    }

    async Task<List<GrupoDTO>> IRequestHandler<GrupoRequest, List<GrupoDTO>>.Handle(GrupoRequest request, CancellationToken cancellationToken)
    {
        var grupos = await _grupoRespository.GetAsync(w => w.IsActive == StatusData.ACTIVE);
        return grupos.Select(grupo => GrupoMapperDTO.ToDTO(grupo)).ToList();
    }
}