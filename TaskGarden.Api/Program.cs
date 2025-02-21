using Microsoft.AspNetCore.Identity;
using TaskGarden.Api;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Middleware;
using TaskGarden.Application;
using TaskGarden.Application.Configurations;
using TaskGarden.Application.Services;
using TaskGarden.Application.Services.Contracts;
using TaskGarden.Domain.Entities;
using TaskGarden.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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