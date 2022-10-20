using System.Diagnostics.CodeAnalysis;
using DrugovichApp.Domain.Entities.Base;

namespace DrugovichApp.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Cliente : EntityBase<Guid>
{
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    
}
