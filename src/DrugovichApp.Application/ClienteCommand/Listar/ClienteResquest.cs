using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.ClienteCommand.Listar;

public class ClienteRequest : IRequest<List<ClienteDTO>>
{
    
}