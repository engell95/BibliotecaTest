using Microsoft.EntityFrameworkCore;
using AdminETL.DbModels;
using BibliotecaApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de Entity Framework Core con InMemoryDatabase
builder.Services.AddDbContext<BibliotecaDbContext>(x => x.UseInMemoryDatabase("AuthorDb"));

builder.Services.AddAllService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();

