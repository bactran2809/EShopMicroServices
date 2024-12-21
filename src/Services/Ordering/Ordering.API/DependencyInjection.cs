namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            return services;
        }

        public static WebApplication UseApiService(this WebApplication application)
        {

            return application;
        }
    }
}
