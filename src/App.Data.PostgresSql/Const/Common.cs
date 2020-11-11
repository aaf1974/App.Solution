namespace App.Data.PostgresSql.Const
{
    /// <summary>
    /// Константы
    /// </summary>
    public static class Common
    {
        /// <summary>
        /// Имя файла с настройками
        /// </summary>
        public static string SettingsFileName = "appsettings.Development.json";

        /// <summary>
        /// Путь к сборке с настройками
        /// </summary>
        public static string PathSettingsAssembly = "../App.API";

        /// <summary>
        /// Сборка с миграциями
        /// </summary>
        public static string MigrationsAssembly = "App.Data.PostgresSql";
    }
}
