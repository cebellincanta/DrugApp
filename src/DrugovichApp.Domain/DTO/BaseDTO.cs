using DrugovichApp.Domain.EnumDrug;

namespace DrugovichApp.Domain.DTO;

public abstract class BaseDTO<TId> where TId : struct
{
    public TId Id { get; set; }
    public DateTime DateCreate { get; set; }
    public StatusData IsActive { get; set; }
}