using App.Domain.Abstraction.Enum;
using App.Models.Dto.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infrastructure.Interfaces
{
    /// <summary>
    /// Интерфейс обработки запросов контроллера для работы со стаичными справочниками
    /// </summary>
    public interface IStaticDictionaryHandler
    {
        /// <summary>
        /// Возвращает перечень статичных справочников
        /// </summary>
        Task<IEnumerable<KeyValueItemDto>> ExecuteGetDictionaryList();

        /// <summary>
        /// Возвращает значения статичного справочника
        /// </summary>
        Task<IEnumerable<KeyValueItemDto>> ExecuteGetDictionary(StaticDictionaryTypes dictionary);
    }
}
