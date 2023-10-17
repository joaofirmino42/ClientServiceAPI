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
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //nome da tabela
            builder.ToTable("Pedido");
            //chave primária
            builder.HasKey(e => e.IdPedido);
            //mapeamento os campos da tabela
            builder.Property(e => e.IdPedido)
            .HasColumnName("IDPEDIDO");
            builder.Property(e => e.NumeroPedido)
           .HasColumnName("NUMEROPEDIDO");
            builder.Property(e => e.DataCriacao)
           .HasColumnName("DATACRIACAO")
            .HasColumnType("datetime");
            builder.Property(f => f.IdCliente)
 .HasColumnName("IDCLIENTE")
 .IsRequired();
            #region Mapeamento de relacionamento 1 para muitos
            // TEM 1 
            builder.HasOne(f => f.Cliente)
            // TEM MUITOS 
            .WithMany(e => e.Pedidos)
           
            .HasForeignKey(f => f.IdCliente);
            //Chave estrangeira
            #endregion

        }
    }
}
