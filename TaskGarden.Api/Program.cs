using Microsoft.AspNetCore.Identity;
using TaskGarden.Api;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Extensions;
using TaskGarden.Application;
using TaskGarden.Application.Configurations;
using TaskGarden.Application.Services;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

builder.Services.AddCorsService();
builder.Services.AddScoped<IUserContextService, UserContextService>();
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddAuthenticationService(builder.Configuration);
builder.Services.AddEmailService();
builder.Services.AddIdentityService();
builder.Services.AddApplicationServices();
builder.Services.AddRepositoryService();
builder.Services.AddValidatorService();

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Add ProblemDetails services before any middleware is called
builder.Services.AddProblemDetails(ExceptionExtensions.ConfigureProblemDetails);

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddSecurityHeaders();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.MapAuthEndpoints();
app.MapCategoryEndpoints();
app.MapTaskListEndpoints();
app.MapInviteEndpoints();

app.Run();
