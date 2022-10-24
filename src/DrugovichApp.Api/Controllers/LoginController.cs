using DrugovichApp.Api.AppSecurity;
using DrugovichApp.Api.ViewModel;
using DrugovichApp.Domain.DTO;
using DrugovichApp.Domain.Entities;
using DrugovichApp.Domain.Interfaces.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichApp.Api.Controllers;

[ApiVersion("1.0")]
[Route("v1/[controller]/[action]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost()]
    public async Task<ActionResult<dynamic>> LoginAsync([FromBody] LoginViewModel login,
                                                        [FromServices] IMediatorHandler<DrugovichApp.Application.UsuarioCommand.Buscar.UsuarioRequest, UsuarioDTO> mediatorHandler) //Viewmodel
    {
        var result = await mediatorHandler.SendQueryAsync(new DrugovichApp.Application.UsuarioCommand.Buscar.UsuarioRequest() { NomeUsuario = login.NomeUsuario, Senha = login.Senha });
        var token = TokenBaseService.Generate(result);
        return new { usuario = result.NomeUsuario, token = token };
    }

}