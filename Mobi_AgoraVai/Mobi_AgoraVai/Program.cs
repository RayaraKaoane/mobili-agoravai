using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Mobi_AgoraVai.Data;

var builder = WebApplication.CreateBuilder(args);


// Configurar a conexão do Entity Framework Core com MySQL
var connectionString = "Server=localhost;User=root;Password=R@y010600;Database=nomedasuabasededados;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 23))));

// Adicione o serviço de controladores
builder.Services.AddControllers();

// Configurar a autorização
builder.Services.AddAuthorization();

// Configurar o Swagger
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minha API", Version = "v1" });
    });
}

var app = builder.Build();

// Configurar o Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
