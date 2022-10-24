using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Alterar;

public class ClienteRequest : IRequest<ClienteDTO>
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("cnpj")]
    public string Cnpj { get; set; }
    [JsonPropertyName("dataFundacao")]
    public DateTime DataFundacao { get; set; }
    [JsonPropertyName("grupoId")]
    public Guid GrupoId { get; set; }
    
}