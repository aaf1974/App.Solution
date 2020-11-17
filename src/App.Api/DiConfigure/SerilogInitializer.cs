using App.Models.Configuration;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace App.Api.DiConfigure
{
    //https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/


    /// <summary>
    /// Инициализация Serilog
    /// </summary>
    static class SerilogInitializer
    {
        //https://nblumhardt.com/2019/10/serilog-in-aspnetcore-3/
        //https://github.com/serilog/serilog-aspnetcore/blob/71165692d5f66c811c3b251047b12c259ac2fe23/samples/EarlyInitializationSample/Program.cs#L12
        /// <summary>
        /// Инициализация Serilog из Program
        /// </summary>
        public static Serilog.Core.Logger InitFromProgram(IConfiguration configuration)
        {
            var config  = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                //.WriteTo.Console(new RenderedCompactJsonFormatter())
                //.WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .WriteTo.Console()
                .WriteTo.Debug()
                .WriteTo.File(GetSerilogFile(configuration))
                .CreateLogger();

            return config;
        }

        /// <summary>
        /// Получает путь к файлу лога из конфиг файла
        /// </summary>
        public static string GetSerilogFile(IConfiguration configuration)
        {
            string filePath = configuration[$"{nameof(LoggingConfig)}:{nameof(LoggingConfig.SerilogLogFile)}"];
            return filePath;
        }


        /// <summary>
        /// Инициализирует Serilog (можно из программ)
        /// </summary>
        public static void SerilogInit(this IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("Serilog:IsStart"))
            {
                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .CreateLogger();
            }
        }

        /// <summary>
        /// Получает флаг включения/отключения из файла конфигурации
        /// </summary>
        public static bool SerilogEnable(this IConfiguration configuration)
        {
            return configuration.GetValue<bool>("Serilog:IsStart");
        }
    }
}
