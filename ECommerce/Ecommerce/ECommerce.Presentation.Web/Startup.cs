using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ECommerce.Infra.IoC;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Presentation.Web
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
     

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>();

            RegisterServices(services);
            services.AddMvc();
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStatusCodePages();
            app.UseStaticFiles();
           
            
            
            //app.UseMvc(route =>
            //{
            //    route.MapRoute(
            //        "admin",
            //        "{area=admin}/{controller=Home}/{action=Index}/{id?}"
            //    );

            //    route.MapRoute(
            //        "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapAreaControllerRoute(
                //    "admin",
                //    "admin",
                //    "{area}/{controller=Home}/{action=Index}/{id?}"
                //);
               
            });

            AppDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
        }
    }
}
