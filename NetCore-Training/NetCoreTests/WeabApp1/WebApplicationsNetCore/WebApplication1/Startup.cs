using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication1
{
    public class Startup
    {
        public Startup()
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando clase Startup");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando método ConfigureServices");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando método Configure");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Map("/garo", app2 =>
            {
                app2.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("Hi");
                    await next.Invoke();
                });

                app2.MapWhen(context => context.Request.Query.Any(cveVal => cveVal.Key == "esteban"), app3 =>
                {
                    app3.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync($";Enrutamiento por MapWhen");
                        await next.Invoke();
                    });

                    app3.Run(async context => await context.Response.WriteAsync("; Fin enrutamiento por MapWhen"));
                });

                //app2.Run(async (context) =>
                //{
                //    await context.Response.WriteAsync($" -> Hello GaRo from ASP .NET Core Application" +
                //        $"{(env.IsEnvironment(EnvironmentName.Development) ? " , Ambiente: Producci&oacute;n" : $" , Ambiente: {env.EnvironmentName}")}!");
                //});
            });


            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hola");
                await next.Invoke();
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($" -> Hello Esteban GaRo from ASP .NET Core Application" +
                    $"{(env.IsEnvironment(EnvironmentName.Development) ? " , Ambiente: Producci&oacute;n" : string.Empty)}!");
            });
        }

        //public void ConfigurePrePro(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    System.Diagnostics.Debug.WriteLine("Ejecutando método Configure");


        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }

        //    app.Run(async (context) =>
        //    {
        //        await context.Response.WriteAsync($"Hello Esteban GaRo from ASP .NET Core Application (PrePro)" +
        //            $"{(env.IsEnvironment(EnvironmentName.Development) ? ", Ambiente: Producci&oacute;n" : string.Empty)}!");
        //    });
        //}
    }
}
