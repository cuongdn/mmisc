using System.Linq;
using Omu.ValueInjecter;

namespace Core.Business.Mapper
{
    public class ExcludeValueInjection : LoopValueInjection
    {
        protected string[] Exclude;

        public ExcludeValueInjection(params string[] propNames)
        {
            Exclude = propNames;
        }

        protected override bool UseSourceProp(string sourcePropName)
        {
            return !Exclude.Contains(sourcePropName);
        }
    }
}