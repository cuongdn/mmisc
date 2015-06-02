
using System.ComponentModel;

namespace Core.Common.Enums
{
    public enum EFilterOperator
    {
        [Description("<")]
        IsLessThan,
        [Description("<=")]
        IsLessThanOrEqualTo,
        [Description("=")]
        IsEqualTo,
        [Description("<>")]
        IsNotEqualTo,
        [Description(">=")]
        IsGreaterThanOrEqualTo,
        [Description(">")]
        IsGreaterThan,
        [Description("StartsWith")]
        StartsWith,
        [Description("EndsWith")]
        EndsWith,
        [Description("Contains")]
        Contains,
        [Description("Contains")]
        IsContainedIn,
        [Description("Contains")]
        DoesNotContain,
    }
}
