using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum JudicalWorkTypeEnum
    {
        [Description("Судебный приказ")]
        [EnumMember]
        Судебный_приказ = 1,

        [Description("Исковое заявление")]
        [EnumMember]
        Исковое_заявление = 2
    }
}
