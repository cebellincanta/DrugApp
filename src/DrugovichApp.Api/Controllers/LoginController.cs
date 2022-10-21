using DrugovichApp.Api.Security;
using DrugovichApp.Api.ViewModel;
using DrugovichApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichApp.Api.Controllers;

[ApiController]
[Route("/v1/[controller]/[action]")]
public class LoginController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<dynamic>> LoginAsync([FromBody] LoginViewModel login) //Viewmodel
    {
        var usuario = new Usuario();
        var token = TokenBaseService.Generate(usuario);
        return new { usuario = usuario.NomeUsuario , token = token};
    }

}