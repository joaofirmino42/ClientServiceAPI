using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApiClientes.Infra.Data.Contexts
{
    public class SqlServerMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        //método utilizado pelo Migrations para inicializar a classe
        //SqlServerContext utilizando os atributos do appsettings.json
        public SqlServerContext CreateDbContext(string[] args)
        {
            //Lendo o arquivo appsettings.json
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),
            "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            //capturar a connectionstring mapeada dentro do arquivo
            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
            .GetSection("BDApiClientes").Value;
            //instanciar a classe SqlServerContext
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionString);
            return new SqlServerContext(builder.Options);
        }

    }
}
