using System.Diagnostics.CodeAnalysis;
using DrugovichApp.Domain.Entities.Base;

namespace DrugovichApp.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Usuario : EntityBase<Guid>
{
    public string NomeUsuario { get; set; }
    public string Senha { get; set; }
    public virtual Gerente Gerente{ get; set; }
}
