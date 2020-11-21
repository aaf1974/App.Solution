using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    /// <summary>
    /// Тип судебного решения
    /// </summary>
    [DataContract]
    public enum JudicalDecisionTypeEnum
    {
        [Description("Судебное решение")]
        [EnumMember]
        Judgment = 1,

        [Description("Судебный приказ")]
        [EnumMember]
        Writ = 2,

        [Description("Прекращение")]
        [EnumMember]
        Termination = 3
    }
}
