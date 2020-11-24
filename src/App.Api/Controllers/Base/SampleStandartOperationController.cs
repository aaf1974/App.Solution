using App.Infrastructure.Handler.Sample;

namespace App.Api.Controllers.Base
{
    /// <summary>
    /// Пример реализации Standart-контроллера 
    /// </summary>
    public class SampleStandartOperationController : StandartOperationController<SampleDtoItem, SampleFilter, SampleList, SampleTabItem>
    {
        public SampleStandartOperationController(SampleStandartOperationHandler blHandler)
            :base(blHandler)
        {

        }
    }
}
