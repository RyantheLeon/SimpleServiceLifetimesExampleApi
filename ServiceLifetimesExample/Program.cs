global using Microsoft.AspNetCore.Mvc;
global using SimpleServiceLifetimesExampleApi.Services;
global using SimpleServiceLifetimesExampleApi.Services.Contracts;
global using SimpleServiceLifetimesExampleApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICustomSingletonService, CustomSingletonService>();
builder.Services.AddScoped<ICustomScopedService, CustomScopedService>();
builder.Services.AddTransient<ICustomTransientService, CustomTransientService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggerHelper>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
