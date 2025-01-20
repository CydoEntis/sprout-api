using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskGarden.Api.Configurations;
using TaskGarden.Api.Constants;
using TaskGarden.Api.Endpoints;
using TaskGarden.Api.Middleware;
using TaskGarden.Api.Services.Contracts;
using TaskGarden.Api.Services.Implementations;
using TaskGarden.Data;
using TaskGarden.Data.Models;
using TaskGarden.Data.Repositories;
using TaskGarden.Data.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
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

// Services
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICookieManager, CookieManager>();
builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddScoped<ISessionManager, SessionManager>();
builder.Services.AddScoped<IEmailTemplateService, EmailTemplateService>();
builder.Services.AddScoped<IEmailService, MailKitService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapAuthEndpoints();


app.Run();