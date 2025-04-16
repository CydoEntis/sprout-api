using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Sprout.Api.Application.DependencyInjection;
using Sprout.Api;
using Sprout.Api.Application.Features.Auth;
using Sprout.Api.Application.Features.Categories;
using Sprout.Api.Application.Features.Invitation;
using Sprout.Api.Application.Features.TaskList;
using Sprout.Api.Application.Features.TaskListItem;
using Sprout.Api.Application.Shared.Extensions;
using Sprout.Api.Domain.Entities;
using Sprout.Api.Infrastructure.DependencyInjection;
using Sprout.Api.Infrastructure.Middlewares;
using Sprout.Api.Infrastructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

// builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(5000); // HTTP
//     options.ListenAnyIP(5001, listenOptions =>
//     {
//         listenOptions.UseHttps();
//     });
// });


// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();

builder.Services.AddCorsService();
builder.Services.AddDatabaseService(builder.Configuration);
builder.Services.AddAuthenticationService(builder.Configuration);
builder.Services.AddIdentityService();
builder.Services.AddApplicationServices();
builder.Services.AddEmailService();

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());

builder.Services.AddIdentityCore<AppUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

// Add ProblemDetails services before any middleware is called
builder.Services.AddProblemDetails(ExceptionExtensions.ConfigureProblemDetails);

var app = builder.Build();

app.UseMiddleware<JwtTokenMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddSecurityHeaders();

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

// 🔒 Redirect HTTP to HTTPS (safe to keep, will be ignored if no HTTP port)
app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return Results.Ok(new { message = "API is working!" });
});


app.MapAuthEndpoints();
app.MapCategoryEndpoints();
app.MapTaskListEndpoints();
app.MapTaskListItemEndpoints();
app.MapInvitationEndpoints();
app.MapTasklistMemberEndpoints();

app.Run();
