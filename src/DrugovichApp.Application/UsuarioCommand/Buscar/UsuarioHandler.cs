using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Exceptions;
using DrugovichApp.Domain.Interfaces.Repositories;
using DrugovichApp.Domain.Mapper;
using DrugovichApp.Domain.VO;
using MediatR;

namespace DrugovichApp.Application.UsuarioCommand.Buscar;
public class UsuarioHandler : IRequestHandler<UsuarioRequest, UsuarioDTO>
{
    private readonly IUsuarioRepository _UsuarioRespository;

    public UsuarioHandler(IUsuarioRepository UsuarioRespository)
    {
        _UsuarioRespository = UsuarioRespository;
    }

    public async Task<UsuarioDTO> Handle(UsuarioRequest request, CancellationToken cancellationToken)
    {
        var erro = new List<ValidacaoErro>();
        var UsuarioJaExtiste = await _UsuarioRespository.GetFirstAsync(x => x.NomeUsuario == request.NomeUsuario && x.Senha == request.Senha);
        if(UsuarioJaExtiste is null)
        {
            erro.Add(new ValidacaoErro("Nome Usuario", $"O Usuario não existe ou senha esta incorreta."));
            throw new NotFoundExcpetionDrug(erro);
        } 

        return UsuarioMapperDTO.ToDTO(UsuarioJaExtiste);
    }
}