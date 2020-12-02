using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Api.DiConfigure;
using App.Data;
using App.Infrastructure.Helper;
using App.Infrastructure.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace App.Api
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
            services.AddControllers();

            services.UseSwagger("Application Api", "Application Api Descriptor")
                .InitPostrgresDbContext(Configuration.GetConnectionString(AppIntegrationEnvrioment.MainAppContextSettingName))
                .UseAppAutoMapper()
                .UseStandartOperationHandlers()
                .UseStaticDictionary()
                ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.SwaggerMidlwareInit();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
