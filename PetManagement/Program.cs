using Microsoft.EntityFrameworkCore;
using PetManagement.Entities;
using PetManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PetDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:LearningProjectsConnection"));

// Services
builder.Services.AddTransient<PetService>();
builder.Services.AddTransient<OwnerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
