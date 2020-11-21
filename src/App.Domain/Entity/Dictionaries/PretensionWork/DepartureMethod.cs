using System.ComponentModel;
using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries.PretensionWork
{
    [DataContract]
    public enum DepartureMethodEnum
    {
        /// <summary> Почта</summary>
        [Description("Почта")]
        [EnumMember]
        Post = 1,

        [Description("ГУП")]
        [EnumMember]
        /// <summary> ГУП</summary>
        GUP = 2
    }
}
