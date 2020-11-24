using App.Models.Command.Base;
using System.Threading.Tasks;

namespace App.Infrastructure.Interfaces
{
    /// <summary>
    /// Обработчик комманд стандратных операций
    /// </summary>
    public interface IStandartOperationHandler
    {

    }


    /// <summary>
    /// <inheritdoc cref="IStandartOperationHandler"/>
    /// </summary>
    /// <typeparam name="TDto">Тип DTO для получения и сохранения объектов</typeparam>
    /// <typeparam name="TGetListCommand">Тип команды для получения списка</typeparam>
    /// <typeparam name="TTabViewDto">Тип для получения табличного представления</typeparam>
    /// <typeparam name="TTabViewItemDto">Тип элемента табличного представления</typeparam>
    public interface IStandartOperationHandler<TDto, TGetListCommand, TTabViewDto, TTabViewItemDto> : IStandartOperationHandler
        where TDto: BaseItemDto
        where TGetListCommand : BaseGetListCommand
        where TTabViewDto: BaseTabViewDto<TTabViewItemDto>
    {
        /// <summary>
        /// Получает объект по ИД
        /// </summary>
        Task<TDto> ExecuteGetById(GetByIdCommand command);

        /// <summary>
        /// Получает список объектов по фильтру
        /// </summary>
        Task<TTabViewDto> ExecuteGetList(TGetListCommand command);

        /// <summary>
        /// Сохраняет или добавляет объект
        /// </summary>
        Task<TDto> ExecuteSave(TDto dto);

        /// <summary>
        /// Удаляет объект по ид
        /// </summary>
        Task ExecuteDelete(GetByIdCommand command);
    }
}
