using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataServiceConfigExtension
    {
        public static IServiceCollection AddData(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> dbContextOptions)
        {
            services.AddDbContext<AabDbContext>(dbContextOptions);

            return services;
        }
    }
}