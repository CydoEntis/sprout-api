using Microsoft.EntityFrameworkCore;
using Sprout.Api.Application.Shared.Constants;
using Sprout.Api.Infrastructure.Persistence;
using Sprout.Application.Common.Constants;

namespace Sprout.Api.Infrastructure.DependencyInjection;

public static class DatabaseServiceRegistration
{
    public static IServiceCollection AddDatabaseService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ProjectConsts.ConnectionString);

        Console.WriteLine(connectionString);

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, options => options.CommandTimeout(360)));

        return services;
    }
}