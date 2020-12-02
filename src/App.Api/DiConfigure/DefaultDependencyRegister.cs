using App.Infrastructure.Handler;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Service;
using App.Infrastructure.Tools;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddSingleton<AppAutoMapperConfig>();

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
    }
}
