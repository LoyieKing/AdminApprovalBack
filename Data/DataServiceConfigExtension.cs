using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Autofac;
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

            services.AddDbContext<DbContext, AabDbContext>(dbContextOptions);


            return services;
        }

        public static ContainerBuilder RegsiterRepo(this ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            return builder;
        }
    }
}