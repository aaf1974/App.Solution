using App.Infrastructure.Handler;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Service;
using App.Infrastructure.Tools;
using AutoMapper;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace App.Api.DiConfigure
{
    /// <summary>
    /// Инициализация стандартных сервисов
    /// </summary>
    public static class DefaultDependencyRegister
    {
        /// <summary>
        /// Инициализаирует AutoMapper
        /// </summary>
        public static IServiceCollection UseAppAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AppAutoMapperConfig));
            return services;
        }


        /// <summary>
        /// Регистрирует сервисы, необходимые для работы StaticDictionary
        /// </summary>
        public static IServiceCollection UseStaticDictionary(this IServiceCollection services)
        {
            services.AddSingleton<StaticDictionaryStorage>()
                .AddScoped<IStaticDictionaryHandler, StaticDictionaryHandler>();
            
            return services;
        }


        /// <summary>
        /// Регистрирует HealthCheck
        /// </summary>
        public static IServiceCollection UseHealthCheck(this IServiceCollection services)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            return services;
        }

        /// <summary>
        /// Регистрирует HealthCheck
        /// </summary>
        public static void UseHealthCheckMidware (this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
            {
                Predicate = r => r.Name.Contains("self")
            });
        }
    }
}
