using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplication1
{
    public class StartupPrePro
    {
        public StartupPrePro()
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando clase Startup");
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando método ConfigureServices");
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            System.Diagnostics.Debug.WriteLine("Ejecutando método Configure");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(async (context, requestDel) =>
            {
                System.Diagnostics.Debug.WriteLine("Iniciando ejecución de middleware medio");
                //Lógica antes de procesamiento de petición.
                System.Diagnostics.Stopwatch Sw = new System.Diagnostics.Stopwatch();
                Sw.Start();
                //await requestDel.Invoke();
                System.Threading.Thread.Sleep(1000);
                await context.Response.WriteAsync("Respuesta establecida en middleware intermedio");
                Sw.Stop();
                //Lógica después de procesamiento de petición.
                System.Diagnostics.Debug.WriteLine("Agregando encabezado personalizado");
                context.Response.Headers.Add("x-time-process", Sw.ElapsedMilliseconds.ToString() + "ms");
            });

            //app.Run(async (context) =>
            //{
            //    System.Threading.Thread.Sleep(1000);
            //    await context.Response.WriteAsync($"Hello Esteban GaRo from ASP .NET Core Application (Startup PrePro)" +
            //        $"{(env.IsEnvironment(EnvironmentName.Development) ? ", Ambiente: Producci&oacute;n" : string.Empty)}!");
            //});
        }
    }
}
