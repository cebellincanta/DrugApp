using DrugovichApp.Domain.Entities;
using DrugovichApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugovichApp.Infrastructure.Mapping;
public class UsuarioMapping : EntityBaseMappingConfiguration<Guid, Usuario>
{
    public override void Map(EntityTypeBuilder<Usuario> builder)
    {
        base.Map(builder);
        builder.ToTable("usuario");
        builder.Property(x => x.NomeUsuario).IsRequired().HasColumnName("nome_usuario").HasColumnType("50");
        builder.Property(x => x.Senha).IsRequired().HasColumnName("senha").HasColumnType("50");
        builder.HasOne(x => x.Gerente).WithOne(x => x.Usuario).HasForeignKey<Gerente>(x => x.UsuarioId);
    }

}

/*
CREATE TABLE IF NOT EXISTS  Usuario (
  id uuid not NULL PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome_usuario VARCHAR(20) UNIQUE NOT NULL,
  senha VARCHAR(50) UNIQUE NOT NULL,
  gerente_id uuid NOT NULL,
  FOREIGN KEY (gerente_id) REFERENCES "gerente" (id)
);
*/