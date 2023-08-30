using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Repositories;
using SistemaDeTarefas.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o contexto do banco de dados com o provedor MySQL
builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<TasksSystemDbContext>(options =>
    {
        var connectionString = builder.Configuration.GetConnectionString("DataBase");

        options.UseMySql(connectionString,
            new MySqlServerVersion(new Version(8, 0, 26))); // Versão do MySQL
    });

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configurar o pipeline de solicitação HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();