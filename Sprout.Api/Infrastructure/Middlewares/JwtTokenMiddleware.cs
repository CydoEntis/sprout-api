using Sprout.Api.Infrastructure.Services.Interfaces;

namespace Sprout.Api.Infrastructure.Middlewares
{
    public class JwtTokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<JwtTokenMiddleware> _logger;
        private readonly IServiceProvider _serviceProvider;

        public JwtTokenMiddleware(RequestDelegate next, ILogger<JwtTokenMiddleware> logger,
            IServiceProvider serviceProvider)
        {
            _next = next;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();

                    var userId = tokenService.ExtractUserIdFromToken(token);
                    context.Items["userId"] = userId;
                }
            }

            await _next(context);
        }
    }
}