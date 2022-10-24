using System.Diagnostics.CodeAnalysis;
using DrugovichApp.Domain.Entities.Base;

namespace DrugovichApp.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Gerente : EntityBase<Guid>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Nivel { get; set; }
    public Guid UsuarioId { get; set;}
    public Usuario Usuario{ get; set; }
    
}
