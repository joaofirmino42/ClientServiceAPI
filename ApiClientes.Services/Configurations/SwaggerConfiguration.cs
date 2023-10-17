using Microsoft.OpenApi.Models;

namespace ApiClientes.Services.Configurations
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de Clientes",
                    Description = "Projeto desenvolvido em NET6 API com   EntityFramework SqlServer",
                Contact = new OpenApiContact
 {
     Name = "Api Clientes",
    
     Email = "joaofirmino6@gmail.com"
 }
                });
            });
        }

    }
}
