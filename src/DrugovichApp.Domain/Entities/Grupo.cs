using System.Diagnostics.CodeAnalysis;
using DrugovichApp.Domain.Entities.Base;

namespace DrugovichApp.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Grupo : EntityBase<Guid>
{
    public string Nome { get; set; }
}
