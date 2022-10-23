using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Alterar;

public class GrupoRequest : IRequest<GrupoDTO>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
}