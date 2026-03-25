using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Orbitly.Infrastructure.Persistence;
using Orbitly.Application.Posts;
using Orbitly.Infrastructure.Repositories;
using Orbitly.Api.Middlewares; 
using FluentValidation;
using Orbitly.Application.Common.Behaviors;
using Orbitly.Application.Connections;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.Load("Orbitly.Application"))
);

builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IConnectionRepository, ConnectionRepository>();

builder.Services.AddValidatorsFromAssembly(Assembly.Load("Orbitly.Application"));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddDbContext<OrbitlyDbContext>(options =>
    options.UseNpgsql("Host=localhost;Port=5432;Database=orbitly;Username=postgres;Password=postgres"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowFrontend");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();