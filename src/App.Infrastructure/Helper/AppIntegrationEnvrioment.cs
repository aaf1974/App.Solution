namespace App.Infrastructure.Helper
{
    public static class AppIntegrationEnvrioment
    {
        /// <summary>
        /// Наименование секции в конфиге для подключения к СУБД
        /// </summary>
        public static string MainAppContextSettingName => nameof(App.Data.AppDbContext);
    }
}
