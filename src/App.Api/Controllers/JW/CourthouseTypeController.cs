using App.Api.Controllers.Base;
using App.Infrastructure.Handler.Sample;
using App.Models.Command.Base;
using App.Models.Dto.JW;

namespace App.Api.Controllers.JW
{
    /// <summary>
    /// Контроллер для управления видами судов
    /// </summary>
    public class CourthouseTypeController 
        : StandartOperationController<CourthouseTypeDto, BaseGetListCommand, BaseTabViewDto<CourthouseTypeTabItemDto>, CourthouseTypeTabItemDto>
    {
        public CourthouseTypeController(BaseStandartOperationHandler blHandler)
            : base(blHandler)
        {

        }
    }
}
