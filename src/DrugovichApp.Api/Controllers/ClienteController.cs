using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Interfaces.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichApp.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("v1/[controller]/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Listar([FromServices] IMediatorHandler<DrugovichApp.Application.ClienteCommand.Listar.ClienteRequest, List<ClienteDTO>> mediatorHandler)
    => await mediatorHandler.SendCommandAsync(new DrugovichApp.Application.ClienteCommand.Listar.ClienteRequest());

        [Authorize(Roles = "UM, DOIS")]
        [HttpGet]
        public async Task<ActionResult<ClienteDTO>> Vizualizar([FromBody] DrugovichApp.Application.ClienteCommand.Buscar.ClienteRequest request,
                                                  [FromServices] IMediatorHandler<DrugovichApp.Application.ClienteCommand.Buscar.ClienteRequest, ClienteDTO> mediatorHandler)
             => await mediatorHandler.SendQueryAsync(new DrugovichApp.Application.ClienteCommand.Buscar.ClienteRequest() { Cnpj = request.Cnpj });

        [Authorize(Roles = "DOIS")]
        [HttpPost]
        public async Task<ActionResult<ClienteDTO>> Adicionar([FromBody] DrugovichApp.Application.ClienteCommand.Adicionar.ClienteRequest request,
                                                            [FromServices] IMediatorHandler<DrugovichApp.Application.ClienteCommand.Adicionar.ClienteRequest, ClienteDTO> mediatorHandler)
        => await mediatorHandler.SendCommandAsync(request);

        [Authorize(Roles = "DOIS")]
        [HttpPut]
        public async Task<ActionResult<ClienteDTO>> Editar([FromBody] DrugovichApp.Application.ClienteCommand.Alterar.ClienteRequest request,
                                                         [FromServices] IMediatorHandler<DrugovichApp.Application.ClienteCommand.Alterar.ClienteRequest, ClienteDTO> mediatorHandler)
        => await mediatorHandler.SendCommandAsync(request);

        [Authorize(Roles = "DOIS")]
        [HttpDelete]
        public async Task Excluir([FromBody] DrugovichApp.Application.ClienteCommand.Excluir.ClienteRequest request,
                                  [FromServices] IMediatorHandler<DrugovichApp.Application.ClienteCommand.Excluir.ClienteRequest, ClienteDTO> mediatorHandler)
        => await mediatorHandler.SendCommandAsync(request);
    }
}
