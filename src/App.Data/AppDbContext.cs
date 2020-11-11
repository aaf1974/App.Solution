using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Создание модели
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.BuildEntitiesConfiguration(Assembly.GetExecutingAssembly());

            modelBuilder.HasPostgresExtension("postgis");
        }
    }
}
