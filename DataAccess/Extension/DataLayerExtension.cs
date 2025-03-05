using DataAccess.Context;
using DataAccess.Repository.Abstractions;
using DataAccess.Repository.Concrate;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extension
{
    public static class DataLayerExtension
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IRepositoryBase<>),typeof(RepositoryBase<>));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork,UnitOfWorks>();

            return services;
        }
    }
}
