using AdminApprovalBack.Services;
using AdminApprovalBack.Services.SystemManage;
using AdminApprovalBack.Services.SystemSecurity;
using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
    public static class ServiceConfigExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<VerifyCodeService>();

            return services;
        }

        public static ContainerBuilder RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<UserService>().InstancePerLifetimeScope();
            builder.RegisterType<DbBackupService>().InstancePerLifetimeScope();
            builder.RegisterType<LogService>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepoService<>)).InstancePerLifetimeScope();

            return builder;
        }
    }
}
