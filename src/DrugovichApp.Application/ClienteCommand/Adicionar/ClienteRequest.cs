using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Adicionar;

public class ClienteRequest : IRequest<ClienteDTO>
{
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public DateTime DataFundacao { get; set; }
    public Guid GrupoId {get; set;}
}