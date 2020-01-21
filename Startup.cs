using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using net_core_bootcamp_b1_mert.Database;
using net_core_bootcamp_b1_mert.Services;

namespace net_core_bootcamp_b1_mert
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Bootcamp B1 API",
                    Description = ".NET Core Bootcamp B1 Mert 2020",
                    License = new OpenApiLicense
                    {
                        Name = "Develop Mert Þen FINDICAK",
                        Url = new Uri("https://stackoverflow.com/users/6231495/cebidex")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.swagger.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddControllers();

            services.AddDbContext<MertDBContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("BootcampDbConnection")));

            services.AddTransient<IEventService,EventService>();
            services.AddTransient<IHWEventService, HWEventService>();
            services.AddTransient<IHWBookService, HWBookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ".Net Core Bootcamp B1 API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
