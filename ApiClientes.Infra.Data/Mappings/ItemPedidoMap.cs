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
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            //nome da tabela
            builder.ToTable("ItemPedido");
            //chave primária
            builder.HasKey(e => e.IdItemPedido);
            //mapeamento os campos da tabela
            builder.Property(e => e.IdItemPedido)
            .HasColumnName("IDITEMPEDIDO");
            builder.Property(e => e.Nome)
.HasColumnName("NOME")
.HasMaxLength(150);
            builder.Property(e => e.Valor)
           .HasColumnName("VALOR")
            .HasColumnType("decimal");
            builder.Property(f => f.IdPedido)
.HasColumnName("IDPEDIDO")
.IsRequired();
            #region Mapeamento de relacionamento 1 para muitos
            // TEM 1 
            builder.HasOne(f => f.Pedido)
            // TEM MUITOS 
            .WithMany(e => e.ItemPedido)
            
            .HasForeignKey(f => f.IdPedido);
            //Chave estrangeira
            #endregion

        }
    }
}
