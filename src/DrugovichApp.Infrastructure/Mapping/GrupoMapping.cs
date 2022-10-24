using DrugovichApp.Domain.Entities;
using DrugovichApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugovichApp.Infrastructure.Mapping;
public class GrupoMapping : EntityBaseMappingConfiguration<Guid, Grupo>
{
    public override void Map(EntityTypeBuilder<Grupo> builder)
    {
        base.Map(builder);
        builder.ToTable("grupo");
        builder.Property(x => x.Nome).IsRequired().HasColumnName("nome").HasColumnType("150");
        

    }

}

/*
CREATE TABLE IF NOT EXISTS Grupo (
  id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(150) UNIQUE NOT NULL
);
*/
