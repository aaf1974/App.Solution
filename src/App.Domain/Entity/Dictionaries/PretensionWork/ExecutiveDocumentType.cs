using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum ExecutiveDocumentTypeEnum
    {
        [Description("Судебный приказ")]
        [EnumMember]
        JudicialOrder = 1,

        [Description("Исполнительный лист")]
        [EnumMember]
        PerformanceList = 2
    }
}
