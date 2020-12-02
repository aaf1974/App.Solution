using AutoMapper;

namespace App.Infrastructure.Tools
{
    /// <summary>
    /// Настройка автомапера для приложения
    /// </summary>
    public class AppAutoMapperConfig : Profile
    {
        public AppAutoMapperConfig()
        {
            Config();
        }

        private void Config()
        {
            ConfigMiscMapping();
        }

        /// <summary>
        /// Mapping for misc object 
        /// </summary>
        /// <param name="cfg"></param>
        private void ConfigMiscMapping()
        {
            
        }
    }
}
