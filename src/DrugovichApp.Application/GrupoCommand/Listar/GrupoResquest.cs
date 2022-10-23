using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Listar;

public class GrupoRequest : IRequest<List<GrupoDTO>>
{
    
}