using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Excluir;

public class ClienteRequest : IRequest<ClienteDTO>
{
    public Guid Id{ get; set; }
    
}