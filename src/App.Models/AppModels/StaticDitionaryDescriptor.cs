using App.Domain.Abstraction.Enum;
using App.Models.Dto.Base;
using System;
using System.Collections.Generic;

namespace App.Models.AppModels
{
    /// <summary>
    /// Дескриптор статичного справочника
    /// </summary>
    public class StaticDitionaryDescriptor
    {
        /// <summary>
        /// Тип справочника
        /// </summary>
        public StaticDictionaryTypes StaticDictionary { get; set; }

        /// <summary>
        /// CLR тип справочника
        /// </summary>
        public Type StaticDictionaryClrType { get; set; }

        /// <summary>
        /// Заголовок справочника
        /// </summary>
        public string StaticDictionaryTitle { get; set; }


        /// <summary>
        /// Элементы справочника
        /// </summary>
        public IEnumerable<KeyValueItemDto> StaticDictionaryItems { get; set; }
    }
}
