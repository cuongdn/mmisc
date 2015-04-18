using System.Collections;
using System.Web.Mvc;
using Blogging.Business.Lookup;
using Core.Web.Lookup;

namespace Blogging.Web.Lookup
{
    public class CategoryLookupHandler : LookupHandler
    {
        public static CategoryLookupHandler Get()
        {
            return new CategoryLookupHandler();
        }

        public SelectList SelectList
        {
            get
            {
                return new SelectList(GetList(), "Id", "CategoryName");
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