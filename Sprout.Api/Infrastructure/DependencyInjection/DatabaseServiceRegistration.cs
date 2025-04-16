using Microsoft.EntityFrameworkCore;
using TaskGarden.Api.Infrastructure.Persistence;
using TaskGarden.Application.Common.Constants;

namespace TaskGarden.Api.Infrastructure.DependencyInjection;

public static class DatabaseServiceRegistration
{
    public static IServiceCollection AddDatabaseService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration[ProjectConsts.ConnectionString];

        Console.WriteLine(connectionString);

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, options => options.CommandTimeout(360)));

        return services;
    }
}