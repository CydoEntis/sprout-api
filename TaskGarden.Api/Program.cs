using Microsoft.AspNetCore.Identity;
using TaskGarden.Api;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Middleware;
using TaskGarden.Application.Configurations;
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