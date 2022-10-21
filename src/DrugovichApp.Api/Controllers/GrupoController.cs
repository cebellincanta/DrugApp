using DrugovichApp.Api.Security;
using DrugovichApp.Api.ViewModel;
using DrugovichApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrugovichApp.Api.Controllers;

[ApiController]
[Route("/v1/[controller]/[action]")]
public class GrupoController : ControllerBase
{
    [Authorize(Roles = "UM, DOIS")]
    public async Task<List<object>> Listar()
    {
        return new List<object>();
    }

    [Authorize(Roles = "UM, DOIS")]
    public async Task<object> Vizualizar()
    {
        return new object();
    }

    [Authorize(Roles = "DOIS")]
    public async Task<object> Adicionar()
    {
        return new object();
    }

    [Authorize(Roles = "DOIS")]
    public async Task<object> Editar()
    {
        return new object();
    }

    [Authorize(Roles = "DOIS")]
    public async Task<object> Excluir()
    {
        return new object();
    }



}