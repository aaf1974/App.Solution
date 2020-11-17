using App.Api.DiConfigure;
using App.Api.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;


namespace App.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = AppHelper.Configuration;
            configuration.SerilogInit();

            //Log.Logger = SerilogInit.InitFromProgram(configuration);

            try
            {
                //Log.Information("Template App start up");
                CreateHostBuilder(args).Run();
            }
            catch (Exception ex)
            {
                //Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }

        public static IWebHost CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSerilog()
                .CaptureStartupErrors(false)
                //.UseUrls(GetKestrelUrls())
                .UseStartup<Startup>()
                .Build();

        //Host.CreateDefaultBuilder(args)
        //        .UseSerilog()
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        //private static IConfiguration GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .AddEnvironmentVariables();

        //    return builder.Build();
        //}

        
    }
}
