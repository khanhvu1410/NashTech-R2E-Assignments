using Microsoft.AspNetCore.Mvc;
using ToDoApiAssignment.Api.Filters;
using ToDoApiAssignment.Application.Interfaces;
using ToDoApiAssignment.Application.Services;
using ToDoApiAssignment.Domain.Interfaces;
using ToDoApiAssignment.Persistence.Data;
using ToDoApiAssignment.Persistence.Interfaces;
using ToDoApiAssignment.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IToDoDbContext, ToDoDbContext>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

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