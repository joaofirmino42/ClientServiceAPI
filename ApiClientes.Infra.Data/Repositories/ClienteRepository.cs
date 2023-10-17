using ApiClientes.Infra.Data.Entities;
using ApiClientes.Infra.Data.Contexts;
using ApiClientes.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiClientes.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly SqlServerContext _context;
        //construtor para injeção de dependência
        public ClienteRepository(SqlServerContext context)
        {
            _context = context;
        }

        public void Alterar(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public List<Cliente> Consultar()
        {
            return _context.Cliente.ToList();

        }

        public void Excluir(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Inserir(Cliente entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public Cliente ObterClientePorEmail(string email)
        {
            return _context.Cliente.SingleOrDefault(e => e.Email.Equals(email));
        }

        public Cliente ObterPorId(int id)
        {
            return _context.Cliente.FirstOrDefault(e => e.IdCliente.Equals(id));
        }
    }
}
