using Core.Common.Infrastructure.Grid;
using Core.Common.Infrastructure.Paging;
using Core.DataAccess.Entities;
using Core.DataAccess.Infrastructure;
using Core.DataAccess.Repositories;

namespace Core.DataAccess.Extensions
{
    public static class RepositoryExtensions
    {
        public static IPagedList<T> GetPaged<T>(this IRepository<T> repository, GridRequest request)
            where T : EntityBase
        {
            return GetPaged(repository.Query(), request);
        }

        public static IPagedList<T> GetPaged<T>(this IQueryFluent<T> query, GridRequest request)
            where T : EntityBase
        {
            return query.Where(request.GetFilters<T>())
                       .OrderBy(request.GetSortExpression())
                       .Paged(request.Page, request.PageSize);
        }
    }
}
