using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Common;
using Data.RepositoryBase;
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
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var iRepos = types.Where(it => it.Namespace?.StartsWith("Data.IRepository.") ?? false && it.IsInterface);
            var repos = types.Where(it => it.Namespace?.StartsWith("Data.Repository.") ?? false && it.IsClass);


            foreach(var repo in repos)
            {
                var irepos = iRepos.Where(irepo => repo.IsAssignableTo(irepo));

                foreach (var irepo in irepos)
                {
                    services.AddScoped(irepo, repo);
                }

            }



            services.AddDbContext<DbContext, AabDbContext>(dbContextOptions);
            //services.AddDbContext<DbContext, AabDbContext>(options =>
            //{
            //    options.UseMySql("Server=mysql.loyieking.com;Database=graduation;Uid=root;Pwd=924558375;", new MySqlServerVersion(new Version(8, 0)));
            //    options.EnableDetailedErrors(true);
            //});


            return services;
        }
    }
}