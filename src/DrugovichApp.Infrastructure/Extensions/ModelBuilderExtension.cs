using DrugovichApp.Domain.Entities.Base;
using DrugovichApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DrugovichApp.Infrastructure.Extensions;

public static class ModelBuilderExtension
{
    public static void AddConfiguration<TId, TEntity>( this ModelBuilder modelBuilder, EntityBaseMappingConfiguration<TId,TEntity> configuration) 
    where  TEntity : EntityBase<TId> where TId : struct
    {
        configuration.Map(modelBuilder.Entity<TEntity>());
    }

}