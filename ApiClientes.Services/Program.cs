using ApiClientes.Services.Configurations;
var builder = WebApplication.CreateBuilder(args);
// Configurando os controllers da aplica��o
builder.Services.AddControllers();
//Adicionando a configura��o do Swagger
SwaggerConfiguration.AddSwagger(builder);
//Adicionando a configura��o do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

// Add services to the container.
var app = builder.Build();
// Habilitar as rotas e endpoints da API
app.UseRouting();
//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});
//Executar os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();