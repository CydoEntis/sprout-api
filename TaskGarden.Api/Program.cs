using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Contracts;
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var conn = builder.Configuration[ProjectConsts.ConnectionString];
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(conn, options => options.CommandTimeout(360)));

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration[JwtConsts.Issuer],
        ValidateAudience = true,
        ValidAudience = builder.Configuration[JwtConsts.Audience],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration[JwtConsts.Secret]))
    };
});


// Repositories
builder.Services.AddScoped<ISessionRepository, SessionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITaskListRepository, TaskListRepository>();
builder.Services.AddScoped<ITaskListAssignmentRepository, TaskListAssignmentRepository>();
builder.Services.AddScoped<ITaskListItemRepository, TaskListItemRepository>();


// Services
builder.Services.AddScoped<IUserContextService, UserContextService>();
// builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICookieService, CookieService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IEmailTemplateService, EmailTemplateService>();
// builder.Services.AddScoped<IEmailService, MailKitService>();
// builder.Services.AddScoped<ICategoryService, CategoryService>();
// builder.Services.AddScoped<ITaskListService, TaskListService>();
// builder.Services.AddScoped<ITaskListAssignmentService, TaskListAssignmentService>();


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

// app.UseMiddleware<ExceptionHandlingMiddleware>();

// app.MapAuthEndpoints();
app.MapCategoryEndpoints();
app.MapTaskListEndpoints();


app.Run();