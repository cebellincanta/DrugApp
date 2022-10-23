using System.Text.Json.Serialization;
using DrugovichApp.Domain.DTO;
using MediatR;

namespace DrugovichApp.Application.GrupoCommand.Excluir;

public class GrupoRequest : IRequest<GrupoDTO>
{
    public Guid Id{ get; set; }
    
}