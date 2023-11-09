using NetCoreApiPostgreSQL.Data;
using NetCoreApiPostgreSQL.Data.Repositories;
 
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


string? connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");

var postgresSQLConnectionConfiguration = new PostgresSQLConfiguraction(connectionString);
builder.Services.AddSingleton(postgresSQLConnectionConfiguration);

builder.Services.AddScoped<IIceRepository, IceCreamRepository>();





var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();
app.UseAuthorization();


app.MapControllers();

app.Run();
