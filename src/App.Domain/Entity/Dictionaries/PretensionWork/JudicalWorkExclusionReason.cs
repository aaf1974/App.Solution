using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum JudicalWorkExclusionReasonEnum
    {
        [Description("Ошибочно введенный")]
        [EnumMember]
        ErrorInput = 1,
    }
}
