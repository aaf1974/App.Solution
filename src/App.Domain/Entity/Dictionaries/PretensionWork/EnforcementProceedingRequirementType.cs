using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum EnforcementProceedingRequirementTypeEnum
    {
        /// <summary>
        /// Имущественное - взносы
        /// </summary>
        [Description("Имущественное - взносы")]
        [EnumMember]
        Property_Contribution = 1,
        /// <summary>
        /// Не имущественное - обеспечение доступа
        /// </summary>
        [Description("Не имущественное - обеспечение доступа")]
        [EnumMember]
        NonProperty_AccessProvide = 2
    }

}
