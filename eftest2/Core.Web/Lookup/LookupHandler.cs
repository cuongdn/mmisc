using System.Collections;
using System.Web.Mvc;

namespace Core.Web.Lookup
{
    public abstract class LookupHandler
    {
        protected IEnumerable InnerList { get; set; }
        protected abstract IEnumerable GetList();

        protected SelectList SelectList(string valueField, string textField, object selectedValue = null)
        {
            return new SelectList(GetList(), valueField, textField, selectedValue);
        }
    }
}