using DrugovichApp.Domain.Entities;
using DrugovichApp.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrugovichApp.Infrastructure.Mapping;
public class ClienteMapping : EntityBaseMappingConfiguration<Guid, Cliente>
{
    public override void Map(EntityTypeBuilder<Cliente> builder)
    {
        base.Map(builder);
        builder.ToTable("Cliente");
        builder.Property(x => x.Nome).IsRequired().HasColumnName("nome").HasColumnType("200");
        builder.Property(x => x.Cnpj).IsRequired().HasColumnName("cnpj").HasColumnType("15");
        builder.Property(x => x.DataFundacao).IsRequired().HasColumnName("data_fundacao").HasColumnType("datetime");
        builder.HasOne(x => x.Grupo).WithMany(x => x.Cliente).HasForeignKey(x => x.GrupoId);

    }

}


/*
CREATE TABLE IF NOT EXISTS  Cliente (
  id uuid DEFAULT gen_random_uuid() PRIMARY KEY,
  date_create TIMESTAMP NOT NULL,
  is_active BIT NOT NULL,
  nome VARCHAR(20) UNIQUE NOT NULL,
  cnpj VARCHAR(15) UNIQUE NOT NULL,
  data_fundacao TIMESTAMP NOT NULL,
  grupo_id uuid NOT NULL,
  FOREIGN KEY (grupo_id) REFERENCES "grupo" (id)
);
*/