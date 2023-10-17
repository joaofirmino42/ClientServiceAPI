using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Infra.Data.Contexts
{
    //Classe para configuração (contexto)
    //do EntityFramework no projeto Infra.Data
    public class SqlServerContext : DbContext
    {
        //construtor para injeção de dependência
        public SqlServerContext
           (DbContextOptions<SqlServerContext> options)
            : base(options)
        {
        }
        //sobrescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //informar cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ItemPedidoMap());
        }
        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }


    }
}
