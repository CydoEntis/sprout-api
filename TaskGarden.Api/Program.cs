using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Middleware;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Application.Configurations;
using TaskGarden.Application.Services;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;
using TaskGarden.Infrastructure.Models;
using TaskGarden.Infrastructure.Repositories;
using TaskGarden.Infrastructure.Repositories.Implementations;
using TaskGarden.Infrastructure.Services.Email;
using TaskGarden.Infrastructure.Services.Identity;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddAuthorization();

builder.Services.AddCorsService();
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddAuthenticationService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddRepositoryService();

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapAuthEndpoints();
app.MapCategoryEndpoints();
app.MapTaskListEndpoints();


app.Run();