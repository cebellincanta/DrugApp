using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Adicionar;

public class GrupoRequest : IRequest<GrupoDTO>
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
}