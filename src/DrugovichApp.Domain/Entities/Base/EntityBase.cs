using System.Diagnostics.CodeAnalysis;

namespace DrugovichApp.Domain.Entities.Base;

[ExcludeFromCodeCoverage]
public abstract class EntityBase<TId> where TId : struct
{
    public Guid Id { get; set; }
    public DateTime DateCreate { get; set; }
    public bool IsActive { get; set; }

}