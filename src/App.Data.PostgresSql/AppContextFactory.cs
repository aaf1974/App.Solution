using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace App.Data.PostgresSql
{
    class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <summary>
        /// Создает контекст данных для подключения к БД
        /// </summary>
        public AppDbContext CreateDbContext(string[] args)
        {
            return GetPostgresContext();
        }

        /// <summary>
        /// Возвращает контекст данных для подключения к БД
        /// </summary>
        private static AppDbContext GetPostgresContext(string connectionString = null)
        {
            System.Console.WriteLine("Start migration");

            if (connectionString == null)
            {
                IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), Const.Common.PathSettingsAssembly))
                .AddJsonFile(Const.Common.SettingsFileName, optional: true)
                .Build();

                connectionString = config.GetConnectionString(nameof(AppDbContext));
            }

            System.Console.WriteLine($"#\t\tconnection: '{connectionString}'");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(connectionString, 
                    x => //x.UseNetTopologySuite()
                    x.MigrationsAssembly(Const.Common.MigrationsAssembly)
                    );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
