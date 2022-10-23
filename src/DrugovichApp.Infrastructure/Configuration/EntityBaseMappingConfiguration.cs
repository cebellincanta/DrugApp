using DrugovichApp.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugovichApp.Infrastructure.Configuration;

public abstract class EntityBaseMappingConfiguration<TId, TEntity> where TEntity : EntityBase<TId> where TId : struct
{
    public virtual void Map(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).IsRequired().HasColumnName("id");
        builder.Property(x => x.DateCreate).IsRequired().HasColumnName("date_create").HasColumnType("datetime");
        builder.Property(x => x.IsActive).IsRequired().HasColumnName("is_active").HasDefaultValue(true);
    }
}