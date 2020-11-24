using App.Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace App.Infrastructure.Tools
{
    /// <summary>
    /// Инициализирует обработчики реализованные от IStandartOperationHandler
    /// </summary>
    public static class StandartOperationHandlerInitializer
    {
        /// <summary>
        /// Инициализирует обработчики реализованные от IStandartOperationHandler
        /// </summary>
        public static IServiceCollection DIRegitr(this IServiceCollection services)
        {
            var type = typeof(IStandartOperationHandler);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)
                && !p.IsAbstract && !p.IsInterface
                //&& !p.IsGenericType
                );

            types.ToList().ForEach(x => services.AddScoped(x));

            return services;
        }
    }
}
