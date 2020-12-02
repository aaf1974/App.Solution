using App.Data;
using App.Domain.Entity.JW;
using App.Models.Command.Base;
using App.Models.Dto.JW;
using AutoMapper;

namespace App.Infrastructure.Handler
{
    public class CourthouseTypeHandler : StandartOperationBaseHandler<CourthouseType, CourthouseTypeDto, BaseGetListCommand, CourthouseTypeTabItemDto>
    {
        public CourthouseTypeHandler(AppDbContext dbContext, IMapper autoMapper) 
            : base(dbContext, autoMapper)
        {
        }
    }
}
