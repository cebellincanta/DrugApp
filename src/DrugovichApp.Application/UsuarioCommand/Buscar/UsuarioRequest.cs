using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.UsuarioCommand.Buscar;

public class UsuarioRequest : IRequest<UsuarioDTO>
{
    [JsonPropertyName("nomeUsuario")]
    public string NomeUsuario { get; set; }
    [JsonPropertyName("senha")]
    public string Senha { get; set; }
}