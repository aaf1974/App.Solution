using System.Runtime.Serialization;

namespace App.Domain.Entity.Dictionaries
{
    [DataContract]
    public enum ComparisonOperatorEnum
    {
        [EnumMember(Value = "Equal")]
        Equal = 1,

        [EnumMember(Value = "NotEqual")]
        NotEqual,

        [EnumMember(Value = "Great")]
        Great,

        [EnumMember(Value = "Less")]
        Less,

        [EnumMember(Value = "GreatOrEqual")]
        GreatOrEqual,

        [EnumMember(Value = "LessOrEqual")]
        LessOrEqual,

        [EnumMember(Value = "Contains")]
        Contains,

        [EnumMember(Value = "NotContains")]
        NotContains
    }
}
