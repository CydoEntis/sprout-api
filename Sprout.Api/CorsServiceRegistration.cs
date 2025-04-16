namespace Sprout.Api;

public static class CorsServiceRegistration
{
    public static IServiceCollection AddCorsService(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.WithOrigins("https://localhost:5173", "http://client-container:5173",
                        "https://client-container:5173")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .WithExposedHeaders("Cross-Origin-Opener-Policy", "Cross-Origin-Embedder-Policy");
            });
        });

        return services;
    }

    public static void AddSecurityHeaders(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Append("Cross-Origin-Opener-Policy", "same-origin");
            context.Response.Headers.Append("Cross-Origin-Embedder-Policy", "require-corp");

            await next.Invoke();
        });
    }
}