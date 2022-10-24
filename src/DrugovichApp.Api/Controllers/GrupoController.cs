using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Interfaces.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichApp.Api.Controllers;

[Authorize]
[ApiVersion("1.0")]
[Route("v1/[controller]/[action]")]
[ApiController]
public class GrupoController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<GrupoDTO>>> Listar([FromServices] IMediatorHandler<DrugovichApp.Application.GrupoCommand.Listar.GrupoRequest, List<GrupoDTO>> mediatorHandler)
        => await mediatorHandler.SendCommandAsync(new DrugovichApp.Application.GrupoCommand.Listar.GrupoRequest());

    [Authorize(Roles = "UM, DOIS")]
    [HttpGet]
    public async Task<ActionResult<GrupoDTO>> Vizualizar([FromBody] DrugovichApp.Application.GrupoCommand.Buscar.GrupoRequest request,
                                             [FromServices] IMediatorHandler<DrugovichApp.Application.GrupoCommand.Buscar.GrupoRequest, GrupoDTO> mediatorHandler)
        => await mediatorHandler.SendQueryAsync(new DrugovichApp.Application.GrupoCommand.Buscar.GrupoRequest() { Id = request.Id });

    [Authorize(Roles = "DOIS")]
    [HttpPost]
    public async Task<ActionResult<GrupoDTO>> Adicionar([FromBody] DrugovichApp.Application.GrupoCommand.Adicionar.GrupoRequest request,
                                                        [FromServices] IMediatorHandler<DrugovichApp.Application.GrupoCommand.Adicionar.GrupoRequest, GrupoDTO> mediatorHandler)
    => await mediatorHandler.SendCommandAsync(request);

    [Authorize(Roles = "DOIS")]
    [HttpPut()]
    public async Task<ActionResult<GrupoDTO>> Editar([FromBody] DrugovichApp.Application.GrupoCommand.Alterar.GrupoRequest request,
                                                     [FromServices] IMediatorHandler<DrugovichApp.Application.GrupoCommand.Alterar.GrupoRequest, GrupoDTO> mediatorHandler)
    => await mediatorHandler.SendCommandAsync(request);


    [Authorize(Roles = "DOIS")]
    [HttpDelete]
    public async Task Excluir([FromBody] DrugovichApp.Application.GrupoCommand.Excluir.GrupoRequest request,
                              [FromServices] IMediatorHandler<DrugovichApp.Application.GrupoCommand.Excluir.GrupoRequest, GrupoDTO> mediatorHandler)
    => await mediatorHandler.SendCommandAsync(request);
}