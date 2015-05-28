using System.Collections;
using System.Web.Mvc;
using Blogging.Business.Lookup;
using Blogging.Web.Localization;
using Core.Web.Lookup;

namespace Blogging.Web.Lookup
{
    public class CategoryLookupHandler : LookupHandler
    {
        public static CategoryLookupHandler Get()
        {
            return new CategoryLookupHandler();
        }

        public string Option
        {
            get { return LookupTexts.CategoryLookupOption; }
        }

        public SelectList SelectList
        {
            get
            {
                return GetSelectList("Id", "CategoryName");
            }
        }

        protected override IEnumerable GetList()
        {
            if (InnerList == null)
            {
                InnerList = CategoryLookup.GetListDto();
            }
            return InnerList;
        }
    }
}