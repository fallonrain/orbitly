using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Orbitly.Infrastructure.Persistence;
using Orbitly.Application.Posts;
using Orbitly.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("Orbitly.Application"))
);

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrbitlyDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=orbitly;Username=postgres;Password=postgres"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();