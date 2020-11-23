using AutoMapper;

namespace App.Infrastructure
{
    public class AutoMapperConfig
    {
        public IMapper Mapper;

        public AutoMapperConfig()
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
