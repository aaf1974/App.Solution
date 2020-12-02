using App.Domain.Abstraction.Enum;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Service;
using App.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Infrastructure.Handler
{
    /// <summary>
    /// <inheritdoc cref="IStaticDictionaryHandler"/>
    /// </summary>
    public class StaticDictionaryHandler : IStaticDictionaryHandler
    {
        #region CTOR

        /// <summary>
        /// <inheritdoc cref="StaticDictionaryStorage"/>
        /// </summary>
        private readonly StaticDictionaryStorage _dictionaryStorage;

        public StaticDictionaryHandler(StaticDictionaryStorage dictionaryStorage)
        {
            _dictionaryStorage = dictionaryStorage ?? throw new ArgumentNullException(nameof(dictionaryStorage));
        }
        #endregion

        public Task<IEnumerable<KeyValueItemDto>> ExecuteGetDictionaryList()
        {
            return _dictionaryStorage.GetDictionaryList();
        }


        public Task<IEnumerable<KeyValueItemDto>> ExecuteGetDictionary(StaticDictionaryTypes dictionary)
        {
            return Task.FromResult( _dictionaryStorage.StaticDictionaries[dictionary].StaticDictionaryItems );
        }
    }
}
