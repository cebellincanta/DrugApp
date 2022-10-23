using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Buscar;

public class ClienteRequest : IRequest<ClienteDTO>
{
    [JsonPropertyName("nome")]
    public string Cnpj { get; set; }
}