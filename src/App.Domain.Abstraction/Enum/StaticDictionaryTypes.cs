using System.ComponentModel;

namespace App.Domain.Abstraction.Enum
{
    /// <summary>
    /// Перечень статичных справочников приложения
    /// </summary>
    public enum StaticDictionaryTypes
    {
        [Description("Перечень справочников"), StaticDictionary(typeof(StaticDictionaryTypes))]
        DictionaryTypes,

        [Description("Пример справочника"), StaticDictionary(typeof(SampleDictionary))]
        SampleDictionary
    }


    public enum SampleDictionary
    {
        [Description("Description Position1")]
        Position1,

        [Description("Description Position2")]
        Position2
    }
}
