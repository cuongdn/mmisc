using Core.Common.Enums;
using Core.Common.Extensions;

namespace Core.Common.Infrastructure.Grid
{
    public class GridSort
    {
        public string Member { get; set; }
        public ESortDirection Direction { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Member, Direction.Description());
        }
    }
}