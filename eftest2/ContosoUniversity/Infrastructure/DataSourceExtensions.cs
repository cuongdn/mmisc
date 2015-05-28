using System.Collections.Generic;
using System.ComponentModel;
using Core.Common.Enums;
using Core.Common.Infrastructure.Grid;
using Core.Common.Infrastructure.Paging;
using Kendo.Mvc;
using Kendo.Mvc.UI;

namespace ContosoUniversity.Infrastructure
{
    public static class DataSourceExtensions
    {
        public static GridRequest ToGridRequest(this DataSourceRequest request)
        {
            return new GridRequest
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Filters = GetFilters(request),
                Sorts = GetSorts(request)
            };
        }

        public static DataSourceResult ToDataSourceResult<T>(this IPagedList<T> pagedList)
        {
            return new DataSourceResult
            {
                Data = pagedList,
                Total = pagedList.TotalItemCount
            };
        }

        private static IList<GridSort> GetSorts(DataSourceRequest request)
        {
            var sorts = new List<GridSort>();
            if (request.Sorts == null) return sorts;

            sorts = new List<GridSort>();
            foreach (var sort in request.Sorts)
            {
                sorts.Add(new GridSort
                {
                    Member = sort.Member,
                    Direction = sort.SortDirection == ListSortDirection.Ascending
                            ? ESortDirection.Ascending : ESortDirection.Descending
                });
            }
            return sorts;
        }

        private static IList<GridFilter> GetFilters(DataSourceRequest request)
        {
            var filters = new List<GridFilter>();
            if (request.Filters == null) return filters;

            foreach (var filterDescriptor in request.Filters)
            {
                var filter = filterDescriptor as FilterDescriptor;
                if (filter != null)
                {
                    filters.Add(new GridFilter
                    {
                        Member = filter.Member,
                        ConvertedValue = filter.ConvertedValue,
                        Operator = GetOperator(filter)
                    });
                }
                // TODO: add composite filter descriptor if need
            }
            return filters;
        }

        private static EFilterOperator GetOperator(FilterDescriptor filter)
        {
            switch (filter.Operator)
            {
                case FilterOperator.DoesNotContain:
                    return EFilterOperator.DoesNotContain;

                case FilterOperator.IsGreaterThan:
                    return EFilterOperator.IsGreaterThan;

                case FilterOperator.IsGreaterThanOrEqualTo:
                    return EFilterOperator.IsGreaterThanOrEqualTo;

                case FilterOperator.IsLessThan:
                    return EFilterOperator.IsLessThan;

                case FilterOperator.IsLessThanOrEqualTo:
                    return EFilterOperator.IsLessThanOrEqualTo;

                case FilterOperator.IsNotEqualTo:
                    return EFilterOperator.IsNotEqualTo;

                case FilterOperator.Contains:
                    return EFilterOperator.Contains;

                case FilterOperator.IsContainedIn:
                    return EFilterOperator.IsContainedIn;

                case FilterOperator.EndsWith:
                    return EFilterOperator.EndsWith;

                case FilterOperator.StartsWith:
                    return EFilterOperator.StartsWith;

                default:
                    return EFilterOperator.IsEqualTo;
            }
        }
    }
}