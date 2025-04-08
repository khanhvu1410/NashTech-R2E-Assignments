using Microsoft.AspNetCore.Mvc;
using PersonApiAssignment.Api.Filters;
using PersonApiAssignment.Application.Interfaces;
using PersonApiAssignment.Application.Services;
using PersonApiAssignment.Domain.Interfaces;
using PersonApiAssignment.Persistence.Data;
using PersonApiAssignment.Persistence.Interfaces;
using PersonApiAssignment.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
     options.Filters.Add<ValidateModelAttribute>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonDbContext, PersonDbContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

// Disable automatic model validation error handling
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

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
