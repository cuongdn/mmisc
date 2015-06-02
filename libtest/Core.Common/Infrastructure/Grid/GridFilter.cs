using Core.Common.Enums;
using Core.Common.Extensions;

namespace Core.Common.Infrastructure.Grid
{
    public class GridFilter
    {
        public object ConvertedValue { get; set; }
        public string Member { get; set; }
        public EFilterOperator Operator { get; set; }

        public string FilterExpression
        {
            get
            {
                switch (Operator)
                {
                    case EFilterOperator.Contains:
                    case EFilterOperator.EndsWith:
                    case EFilterOperator.StartsWith:
                        return string.Format("{0}.{1}(@0)", Member, Operator.Description());

                    case EFilterOperator.DoesNotContain:
                        return string.Format("!{0}.{1}(@0)", Member, Operator.Description());
                    case EFilterOperator.IsContainedIn:
                        return string.Format("!@0.{1}({0})", Member, Operator.Description());

                    default:
                        return string.Format("{0} {1} @0", Member, Operator.Description());
                }
            }
        }
    }
}