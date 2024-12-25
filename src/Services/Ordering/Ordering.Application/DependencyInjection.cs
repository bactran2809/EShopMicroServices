using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {

            return services;
        }

        public static WebApplication UseApiSerices(this WebApplication app)
        {

            return app;
        }
    }
}
