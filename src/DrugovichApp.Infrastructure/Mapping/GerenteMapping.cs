using DrugovichApp.Domain.Entities;
using DrugovichApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugovichApp.Infrastructure.Mapping;
public class GerenteMapping : EntityBaseMappingConfiguration<Guid, Gerente>
{
    public override void Map(EntityTypeBuilder<Gerente> builder)
    {
        base.Map(builder);
        builder.ToTable("gerente");
        builder.Property(x => x.Nome).IsRequired().HasColumnName("nome").HasColumnType("200");
        builder.Property(x => x.Email).IsRequired().HasColumnName("email").HasColumnType("200");
        builder.Property(x => x.Nivel).IsRequired().HasColumnName("nivel").HasColumnType("10");
        builder.Property(x => x.UsuarioId).IsRequired().HasColumnName("usuario_id");

    }

}

/*
CREATE TABLE IF NOT EXISTS  Gerente (
  id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(200) UNIQUE NOT NULL,
  email VARCHAR(200) UNIQUE NOT NULL,
  nivel VARCHAR(10) NOT NULL
);
*/

