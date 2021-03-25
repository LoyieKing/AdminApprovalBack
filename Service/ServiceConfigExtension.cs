using AdminApprovalBack.Services;
using AdminApprovalBack.Services.SystemManage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceConfigExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<VerifyCodeService>();

            services.AddScoped<AreaApp>();

            return services;
        }
    }
}
