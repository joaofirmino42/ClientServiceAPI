using ApiClientes.Services.Configurations;
var builder = WebApplication.CreateBuilder(args);
// Configurando os controllers da aplicação
builder.Services.AddControllers();
//Adicionando a configuração do Swagger
SwaggerConfiguration.AddSwagger(builder);
//Adicionando a configuração do EntityFramework
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
//Executar os serviços
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();