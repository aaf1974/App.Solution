using App.Infrastructure.Interfaces;
using App.Models.Command.Base;
using App.Models.Command.Common;
using App.Models.Dto.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace App.Api.Controllers.Base
{
    /// <summary>
    /// Контроллер для реализации стандартных функций
    /// </summary>
    public abstract class StandartOperationController<TDto, TGetListCommand, TTabViewDto, TTabViewItemDto> : BaseAppController
        where TDto : BaseItemDto
        where TGetListCommand : BaseGetListCommand
        where TTabViewDto : BaseTabViewDto<TTabViewItemDto>
    {
        #region CTOR
        /// <summary>
        /// <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewDto, TTabViewItemDto}"/>
        /// </summary>
        private readonly IStandartOperationHandler<TDto, TGetListCommand, TTabViewDto, TTabViewItemDto> _businesLogicHandler;

        protected StandartOperationController(IStandartOperationHandler<TDto, TGetListCommand, TTabViewDto, TTabViewItemDto> businesLogicHandler)
        {
            _businesLogicHandler = businesLogicHandler ?? throw new ArgumentNullException(nameof(businesLogicHandler));
        }
        #endregion


        /// <summary>
        /// <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewDto, TTabViewItemDto}.ExecuteGetById"/>
        /// </summary>
        [HttpPost(nameof(GetById))]
        public async Task<TDto> GetById(GetByIdCommand command)
        {
            return await _businesLogicHandler.ExecuteGetById(command);
        }


        /// <summary>
        /// <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewDto, TTabViewItemDto}.ExecuteGetList"/>
        /// </summary>
        [HttpPost(nameof(GetList))]
        public async Task<TTabViewDto> GetList(TGetListCommand command)
        {
            return await _businesLogicHandler.ExecuteGetList(command);
        }

        /// <summary>
        /// <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewDto, TTabViewItemDto}.ExecuteSave"/>
        /// </summary>
        [HttpPost(nameof(Save))]
        public async Task<TDto> Save(TDto dto)
        {
            return await _businesLogicHandler.ExecuteSave(dto);
        }

        /// <summary>
        /// <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewDto, TTabViewItemDto}.ExecuteDelete"/>
        /// </summary>
        [HttpPost(nameof(Delete))]
        public async Task Delete(GetByIdCommand command)
        {
            await _businesLogicHandler.ExecuteDelete(command);
        }
    }
}
