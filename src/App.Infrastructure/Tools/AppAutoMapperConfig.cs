using App.Domain.Entity.JW;
using App.Models.Dto.JW;
using AutoMapper;
using System;

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
            ConfigJudicalWorkMapping();
        }


        /// <summary>
        /// Mapping for misc object 
        /// </summary>
        /// <param name="cfg"></param>
        private void ConfigMiscMapping()
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
