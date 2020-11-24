using App.Infrastructure.Interfaces;
using App.Models.Command.Base;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure.Handler.Sample
{
    /// <summary>
    /// Пример реализации <inheritdoc cref="IStandartOperationHandler"/>
    /// </summary>
    public class SampleStandartOperationHandler : IStandartOperationHandler<SampleDtoItem, SampleFilter, SampleList, SampleTabItem>
    {
        public Task ExecuteDelete(GetByIdCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<SampleDtoItem> ExecuteGetById(GetByIdCommand command)
        {
            throw new NotImplementedException();
        }


        public Task<SampleDtoItem> ExecuteSave(SampleDtoItem dto)
        {
            throw new NotImplementedException();
        }

        public Task<SampleList> ExecuteGetList(SampleFilter command)
        {
            throw new NotImplementedException();
        }
    }

    public class SampleDtoItem : BaseItemDto
    {
    }

    public class SampleFilter : BaseGetListCommand
    {
    }

    public class SampleList : BaseTabViewDto<SampleTabItem>
    {

    }

    public class SampleTabItem
    {

    }
}
