using System.Diagnostics.CodeAnalysis;
using DrugovichApp.Domain.EnumDrug;

namespace DrugovichApp.Domain.Entities.Base;

[ExcludeFromCodeCoverage]
public abstract class EntityBase<TId> where TId : struct
{
    public TId Id { get; set; }
    public DateTime DateCreate { get; set; }
    public StatusData IsActive { get; set; }

}