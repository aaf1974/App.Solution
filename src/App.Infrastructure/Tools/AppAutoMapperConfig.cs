using App.Domain.Entity.JW;
using App.Models.Dto.JW;
using AutoMapper;
using System;

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
                ConfigJudicalWorkMapping(cfg);
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


        /// <summary>
        /// Настройка маппинга для JW
        /// </summary>
        private void ConfigJudicalWorkMapping(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CourthouseType, CourthouseTypeDto>()
                .ReverseMap();

            cfg.CreateMap<CourthouseType, CourthouseTypeTabItemDto>();
        }
    }
}
