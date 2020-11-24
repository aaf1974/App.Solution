using App.Api.Controllers.Base;
using App.Infrastructure.Handler;
using App.Models.Command.Base;
using App.Models.Dto.Base;
using App.Models.Dto.JW;

namespace App.Api.Controllers.JW
{
    /// <summary>
    /// Контроллер для управления видами судов
    /// </summary>
    public class CourthouseTypeController 
        : StandartOperationController<CourthouseTypeDto, BaseGetListCommand, BaseTabViewDto<CourthouseTypeTabItemDto>, CourthouseTypeTabItemDto>
    {
        public CourthouseTypeController(CourthouseTypeHandler blHandler)
            : base(blHandler)
        {

        }
    }
}
