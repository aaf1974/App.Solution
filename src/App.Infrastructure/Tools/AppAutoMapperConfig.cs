using AutoMapper;

namespace App.Infrastructure.Tools
{
    /// <summary>
    /// Настройка автомапера для приложения
    /// </summary>
    public class AppAutoMapperConfig
    {
        public IMapper Mapper;

        public AppAutoMapperConfig()
        {
            Config();
        }

        private void Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                ConfigMiscMapping(cfg);
            }
            );

            Mapper = config.CreateMapper();
        }

        /// <summary>
        /// Mapping for misc object 
        /// </summary>
        /// <param name="cfg"></param>
        private void ConfigMiscMapping(IMapperConfigurationExpression cfg)
        {

        }
    }
}
