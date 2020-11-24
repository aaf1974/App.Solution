using App.Domain.Entity.JW;
using App.Models.Dto.JW;
using AutoMapper;
using System;

namespace App.Infrastructure.Tools
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
