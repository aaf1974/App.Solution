using App.Domain.Abstraction.Enum;
using App.Infrastructure.Helper;
using App.Models.AppModels;
using App.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Infrastructure.Service
{
    /// <summary>
    /// Хранилище статичных справочников
    /// </summary>
    public class StaticDictionaryStorage
    {
        #region CTOR

        /// <summary>
        /// 
        /// </summary>
        private Lazy<Dictionary<StaticDictionaryTypes, StaticDitionaryDescriptor>> _staticDctionariesHolder;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<StaticDictionaryTypes, StaticDitionaryDescriptor> StaticDictionaries => _staticDctionariesHolder.Value;

        public StaticDictionaryStorage()
        {
            _staticDctionariesHolder = new Lazy<Dictionary<StaticDictionaryTypes, StaticDitionaryDescriptor>>(PrepareDictionaryList, true);
        }

        #endregion

        /// <summary>
        /// Получение статичных справочников
        /// </summary>
        /// <returns></returns>
        private Dictionary<StaticDictionaryTypes, StaticDitionaryDescriptor> PrepareDictionaryList()
        {
            IEnumerable<StaticDitionaryDescriptor> staticDictionaries = StaticDictionaryTypesHelper.LtcGetEnumCollection<StaticDictionaryTypes>()
                .GetStaticDitionaryDescriptor();

            return staticDictionaries.ToDictionary(x => x.StaticDictionary, x => x);
        }

        /// <summary>
        /// Возвращает перечень статичных справочников
        /// </summary>
        internal Task<IEnumerable<KeyValueItemDto>> GetDictionaryList()
        {
            var result =  StaticDictionaries
                .Select(x => 
                    new KeyValueItemDto 
                    { 
                        Key = (int)x.Value.StaticDictionary, Value = x.Value.StaticDictionaryTitle 
                    }
                    );

            return Task.FromResult(result);
        }
    }
}
