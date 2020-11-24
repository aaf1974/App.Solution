using App.Data;
using App.Domain.Entity.JW;
using App.Infrastructure.Tools;
using App.Models.Command.Base;
using App.Models.Dto.JW;

namespace App.Infrastructure.Handler
{
    public class CourthouseTypeHandler : StandartOperationBaseHandler<CourthouseType, CourthouseTypeDto, BaseGetListCommand, CourthouseTypeTabItemDto>
    {
        public CourthouseTypeHandler(AppDbContext dbContext, AppAutoMapperConfig autoMapper) 
            : base(dbContext, autoMapper)
        {
        }
    }
}
