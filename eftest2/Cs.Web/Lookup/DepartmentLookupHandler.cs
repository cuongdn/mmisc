using System.Collections;
using System.Web.Mvc;
using Core.Web.Lookup;
using Cs.Business.Lookup;
using Cs.Localization.Texts;

namespace Cs.Web.Lookup
{
    public class DepartmentLookupHandler : LookupHandler
    {
        public static DepartmentLookupHandler Get()
        {
            return new DepartmentLookupHandler();
        }

        public static string OptionLabel
        {
            get { return LookupTexts.Department_OptionLabel; }
        }

        private DepartmentLookupHandler()
        {

        }

        public SelectList SelectList
        {
            get { return GetSelectList("Id", "Name"); }
        }

        protected override IEnumerable GetList()
        {
            return InnerList ?? (InnerList = DepartmentLookup.GetList().Result);
        }
    }
}
