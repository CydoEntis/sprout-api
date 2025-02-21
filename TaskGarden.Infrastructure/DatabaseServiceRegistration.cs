using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskGarden.Application.Common.Constants;
using TaskGarden.Application.Common.Contracts;
using TaskGarden.Infrastructure.Repositories.Implementations;

namespace TaskGarden.Infrastructure;

public static class DatabaseServiceRegistration
{
    public static IServiceCollection AddDatabaseService(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration[ProjectConsts.ConnectionString];

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString, options => options.CommandTimeout(360)));



        return services;
    }
}