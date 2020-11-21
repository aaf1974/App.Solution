using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum EnforcementProceedingEventTypeEnum
    {
        /// <summary>
        /// Возбужденно
        /// </summary>
        [Description("Возбужденно")]
        [EnumMember]
        Heatedly = 1,

        /// <summary>
        /// Возобновленно
        /// </summary>
        [Description("Возобновленно")]
        [EnumMember]
        Renewal = 2,

        /// <summary>
        /// Пиостановленно
        /// </summary>
        [Description("Пиостановленно")]
        [EnumMember]
        Suspense = 3,

        /// <summary>
        /// Отложенно
        /// </summary>
        [Description("Отложенно")]
        [EnumMember]
        Lazily = 4,

        /// <summary>
        /// Окончание
        /// </summary>
        [Description("Окончание")]
        [EnumMember]
        Ending = 5
    }
}
