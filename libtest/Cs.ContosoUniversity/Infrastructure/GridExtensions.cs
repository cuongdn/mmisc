using System.Web.Mvc;
using System.Web.Mvc.Html;
using Core.Common.Enums;
using Kendo.Mvc.UI.Fluent;

namespace Cs.ContosoUniversity.Infrastructure
{
    public static class GridExtensions
    {
        public static GridBoundColumnBuilder<TModel> ColumnAction<TModel>(this GridBoundColumnBuilder<TModel> builder, string title = null)
            where TModel : class
        {
            return builder.Sortable(false).Filterable(false).Title(title);
        }

        public static MvcHtmlString FilterTextBox(this HtmlHelper html, string name, EFilterOperator filterOperator, string member = null, object value = null)
        {
            return html.TextBox(name, value, new
            {
                data_filter = string.Empty,
                data_field = member ?? name,
                data_op = ToStringFilterOperator(filterOperator)
            });
        }

        public static MvcForm BeginFormFilter(this HtmlHelper html, string gridName)
        {
            return html.BeginForm(null, null, FormMethod.Get, new { id = string.Format("{0}_filter", gridName) });
        }

        private static string ToStringFilterOperator(EFilterOperator fileOperator)
        {
            switch (fileOperator)
            {
                case EFilterOperator.IsEqualTo:
                    return "eq";
                case EFilterOperator.IsGreaterThan:
                    return "gt";
                case EFilterOperator.IsGreaterThanOrEqualTo:
                    return "gte";
                case EFilterOperator.IsLessThan:
                    return "lt";
                case EFilterOperator.IsLessThanOrEqualTo:
                    return "lte";
                case EFilterOperator.IsNotEqualTo:
                    return "neq";
                default:
                    return fileOperator.ToString().ToLower();
            }
        }
    }
}