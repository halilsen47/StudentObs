using web.ActionFilters;

namespace web.Extensions
{
    public static class ServiceExtensionApı
    {
        public static void ConfigureActionFilter(this IServiceCollection services)
        {
            services.AddScoped<ValidationActionAttribute>();
            services.AddScoped<LogActionAttribute>();
        }
    }
}
