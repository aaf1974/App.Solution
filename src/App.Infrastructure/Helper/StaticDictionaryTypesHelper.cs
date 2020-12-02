using App.Domain.Abstraction.Enum;
using App.Models.AppModels;
using App.Models.Dto.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace App.Infrastructure.Helper
{
    /// <summary>
    /// Helper для обработки StaticDictionaryTypes и StaticDictionaryAttribute
    /// </summary>
    public static class StaticDictionaryTypesHelper
    {
        /// <summary>
        /// Получает список элементов Enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TEnum> LtcGetEnumCollection<TEnum>()
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }

        /// <summary>
        /// Формирует дескрипторы для StaticDictionaryTypes
        /// </summary>
        /// <param name="staticDictionaries"></param>
        /// <returns></returns>
        public static IEnumerable<StaticDitionaryDescriptor> GetStaticDitionaryDescriptor(this IEnumerable<StaticDictionaryTypes> staticDictionaries)
        {
            var result = staticDictionaries.Select(
                x => new StaticDitionaryDescriptor 
                { 
                    StaticDictionary = x,
                    StaticDictionaryClrType = x.GetStaticDictionaryClrType(),
                    StaticDictionaryTitle = x.GetStaticDictionaryTitle(),
                    StaticDictionaryItems = GetStaticDictionaryItems(x.GetStaticDictionaryClrType())
                }
                );

            return result;
        }

        /// <summary>
        /// Получает заголовк статичного справочника
        /// </summary>
        private static string GetStaticDictionaryTitle(this StaticDictionaryTypes staticDictionary)
        {
            return staticDictionary.GetAttributeValue<DescriptionAttribute, string>(x => x.Description);
        }

        /// <summary>
        /// Получает ClrType статичного справочника
        /// </summary>
        private static Type GetStaticDictionaryClrType(this StaticDictionaryTypes staticDictionary)
        {
            return staticDictionary.GetAttributeValue<StaticDictionaryAttribute, Type>(x => x.EnumType);
        }

        /// <summary>
        /// Получает перечень элементов статичного справочника
        /// </summary>
        private static IEnumerable<KeyValueItemDto> GetStaticDictionaryItems(Type type)
        {
            Array enumItems = Enum.GetValues(type);
            foreach(var item in enumItems)
            {
                yield return new KeyValueItemDto
                {
                    Key = Convert.ToInt32(Enum.Parse(type, item.ToString())), //(item as int?).Value,
                    Value = GetDescription(item as System.Enum)
                };
            }
        }

        /// <inheritdoc cref="GetAttributeValue{T, Expected}(Enum, Func{T, Expected}, MemberInfo[])"/>
        public static Expected GetAttributeValue<T, Expected>(this Enum enumeration, Func<T, Expected> expression)
            where T : Attribute
        {
            var members = enumeration
                .GetType()
                .GetMember(enumeration.ToString());

            return enumeration.GetAttributeValue(expression, members);
        }

        /// <summary>
        /// Возвращает значение свойства аттрибута для Enum
        /// </summary>
        public static Expected GetAttributeValue<T, Expected>(this Enum enumeration, Func<T, Expected> expression, MemberInfo[] members)
            where T : Attribute
        {
            T attribute =
              members
                .Where(member => member.MemberType == MemberTypes.Field)
                .FirstOrDefault()
                .GetCustomAttributes(typeof(T), false)
                .Cast<T>()
                .SingleOrDefault();

            if (attribute == null)
                return default(Expected);

            return expression(attribute);
        }

        /// <summary>
        /// Возвращает значение свойства Description из DescriptionAttribute Enum'a 
        /// </summary>
        public static string GetDescription(this Enum enumValue)
        {
            string output = null;
            Type type = enumValue.GetType();
            FieldInfo fi = type.GetField(enumValue.ToString());
            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attrs.Length > 0) output = attrs[0].Description;
            return output;
        }
    }
}
