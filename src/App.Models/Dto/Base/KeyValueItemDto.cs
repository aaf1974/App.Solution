namespace App.Models.Dto.Base
{
    /// <summary>
    /// Типичный объект для предачи данных типа <int, string>
    /// </summary>
    public class KeyValueItemDto : KeyValueItemDto<int, string>
    {
    }


    /// <summary>
    /// Типичный объект для предачи данных типа <int, string>
    /// </summary>
    public class StaticDictionaryItemDto : KeyValueItemDto<int, string>
    {
        public object EnumValue { get; set; }
    }

    public class KeyValueItemDto<TKey, TValue>
    {
        public TKey Key { get; set;  }
        public TValue Value { get; set; }
    }
}
