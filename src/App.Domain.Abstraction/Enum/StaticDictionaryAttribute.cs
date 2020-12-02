using System;

namespace App.Domain.Abstraction.Enum
{

    /// <summary>
    /// Атрибут для StaticDictionaryTypes
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class StaticDictionaryAttribute : Attribute
    {
        public Type EnumType { get; }

        public StaticDictionaryAttribute(Type enumType)
        {
            EnumType = enumType;
        }


    }
}
