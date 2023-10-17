using ApiClientes.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiClientes.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>

    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //nome da tabela
            builder.ToTable("Cliente");
            //chave primária
            builder.HasKey(e => e.IdCliente);
            //mapeamento os campos da tabela
            builder.Property(e => e.IdCliente)
            .HasColumnName("IDCliente");
            builder.Property(e => e.Nome)
 .HasColumnName("NOME")
 .HasMaxLength(150)
           .IsRequired();
            builder.Property(e => e.Email)
 .HasColumnName("EMAIL")
 .HasMaxLength(150)
 .IsRequired();



        }
    }
}
