using App.Domain.Abstraction.Enum;
using App.Infrastructure.Interfaces;
using App.Models.Dto.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    /// <summary>
    /// Контроллер для получения данных статичных спрвочников
    /// </summary>
    public class DictionaryController : BaseAppController
    {
        #region CTOR
        /// <summary>
        /// <inheritdoc cref="IStaticDictionaryHandler"/>
        /// </summary>
        private readonly IStaticDictionaryHandler _handler;

        public DictionaryController(IStaticDictionaryHandler handler)
        {
            _handler = handler;
        }

        #endregion


        /// <summary>
        /// Возвращает перечень статичных справочников
        /// </summary>
        [HttpGet]
        [HttpGet(nameof(Index))]
        public Task<IEnumerable<KeyValueItemDto>> Index(StaticDictionaryTypes? dictionary)
        {
            if (dictionary.HasValue)
                return _handler.ExecuteGetDictionary(dictionary.Value);
            else
                return _handler.ExecuteGetDictionaryList();
        }
    }
}
