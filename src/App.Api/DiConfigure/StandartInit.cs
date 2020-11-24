using App.Infrastructure.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.DiConfigure
{
    /// <summary>
    /// Инициализация стандартных сервисов
    /// </summary>
    public static class StandartInit
    {
        /// <summary>
        /// Инициализаирует AutoMapper
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection InitAppAutoMapper(this IServiceCollection services)
        {
            services.AddSingleton<AutoMapperConfig>();
            return services;
        }
    }
}
