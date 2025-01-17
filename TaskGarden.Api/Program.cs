using TaskGarden.Api.Services.Contracts;
using TaskGarden.Api.Services.Implementations;
using TaskGarden.Data.Repositories;
using TaskGarden.Data.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repositorys
builder.Services.AddScoped<ISessionRepository, SessionRepository>();

// Services
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<ICookieManager, CookieManager>();
builder.Services.AddScoped<ITokenManager, TokenManager>();
builder.Services.AddScoped<IEmailTemplateService, EmailTemplateService>();
builder.Services.AddScoped<IEmailService, MailKitService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
