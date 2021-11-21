using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services;

namespace DemoApiRest
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true,
                reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true,
                reloadOnChange: true);

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        string corsPolicy = "AllowAllOrigins";

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IPersonaRepository, PersonaRepository>().AddTransient<IPersonaService, PersonaService>();

            services.AddCors(options => {
                options.AddPolicy(corsPolicy, builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });

            /* Conexion con Json file */
            //services.AddDbContext<DemoDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString
            //        ("Conexion"));
            //});

            /* Variables y Conexion por defecto */
            var server = Environment.GetEnvironmentVariable("SERVER") ?? "192.168.0.13\\SQLEXPRESS";
            var database = Environment.GetEnvironmentVariable("DATABASE") ?? "DemoApiRestDB";
            var user = Environment.GetEnvironmentVariable("USER") ?? "sa";
            var password = Environment.GetEnvironmentVariable("PASSWORD") ?? "123456";

            services.AddDbContext<DemoDbContext>(options =>
                options.UseSqlServer($"Server={server};Initial Catalog={database};User ID={user};Password={password};Integrated Security=True;Trusted_Connection=False"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(corsPolicy);
        }
    }
}
