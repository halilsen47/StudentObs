using Microsoft.Extensions.DependencyInjection;
using Service.Services.Abstractions;
using Service.Services.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Extension
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddSingleton<ILoggerService, LoggerService>();
            return services;
        }
    }
}
