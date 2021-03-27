using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data;
using Service;
using Middleware;
using Microsoft.EntityFrameworkCore;

namespace AdminApprovalBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddData(options =>
            {
                options.UseMySql("Server=mysql.loyieking.com;Database=graduation;Uid=root;Pwd=924558375;", new MySqlServerVersion(new Version(8, 0)));
                options.EnableDetailedErrors(true);
            });
            services.AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.Use(LoginMiddleware.LoginHandler);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{action=index}/");

                endpoints.MapAreaControllerRoute("SystemManage", "SystemManage", "api/sysmanage/{controller}/{action=index}/");
                endpoints.MapAreaControllerRoute("SystemSecurity", "SystemSecurity", "api/syssec/{controller}/{action=index}/");

            });

            
            
            
        }
    }
}