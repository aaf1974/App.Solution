using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Api.DiConfigure
{
    /// <summary>
    /// Инициализация БД
    /// </summary>
    static class DataBaseInit
    {
        /// <summary>
        /// Инициализация Postrgres DataBase 
        /// </summary>
        public static void InitPostrgresDbContext(this IServiceCollection services, string connectionstring)
        {
            DbContextOptionsBuilder<AppDbContext> InitContextOptions(DbContextOptionsBuilder<AppDbContext> options)
            {
                return options.UseNpgsql(connectionstring, 
                    x => x.MigrationsAssembly(Data.PostgresSql.Const.Common.MigrationsAssembly));
            }

            services.AddDbContext<AppDbContext>(options => InitContextOptions(options as DbContextOptionsBuilder<AppDbContext>));

            services.AddSingleton<Func<AppDbContext>>(s => () =>
            {
                var options = InitContextOptions(new DbContextOptionsBuilder<AppDbContext>()).Options;
                return new AppDbContext(options);
            });
        }
    }
}
