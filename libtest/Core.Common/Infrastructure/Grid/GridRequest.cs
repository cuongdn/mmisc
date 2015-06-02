using System.Collections.Generic;
using Core.Common.Infrastructure.Query;

namespace Core.Common.Infrastructure.Grid
{
    public class GridRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public IList<GridFilter> Filters { get; set; }
        public IList<GridSort> Sorts { get; set; }

        public string GetSortExpression()
        {
            return string.Join(", ", Sorts);
        }

        public QueryObject<T> GetFilters<T>()
        {
            var queryObject = new QueryObject<T>();
            foreach (var filter in Filters)
            {
                queryObject.And(filter.FilterExpression, filter.ConvertedValue);
            }
            return queryObject;
        }
    }
}
