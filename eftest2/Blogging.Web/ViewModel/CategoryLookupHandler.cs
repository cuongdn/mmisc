using System.Collections;
using System.Web.Mvc;
using Blogging.Business.Lookup;
using Core.Web.Lookup;

namespace Blogging.Web.ViewModel
{
    public class CategoryLookupHanlder : LookupHandler
    {
        public static CategoryLookupHanlder Get()
        {
            return new CategoryLookupHanlder();
        }

        public SelectList SelectList
        {
            get
            {
                return SelectList("Id", "CategoryName");
            }
        }

        protected override IEnumerable GetList()
        {
            if (InnerList == null)
            {
                InnerList = CategoryLookupList.Get();
            }
            return InnerList;
        }
    }
}