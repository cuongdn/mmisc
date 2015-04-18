using System;
using System.Web.Mvc;
using Core.Business.Common;
using Core.Web.ViewModel;

namespace Core.Web.Infrastrcture
{
    public class BaseController : Controller
    {
        protected ActionResult ViewOr404<T>(ViewModelBase<T> viewModel, Func<ActionResult> renderView)
            where T : ModelEditBase
        {
            if (viewModel.NotFound)
            {
                return HttpNotFound();
            }
            return renderView();
        }

        protected bool SaveObject<T>(T model, bool forceUpdate = false)
            where T : ModelEditBase
        {
            if (ModelState.IsValid)
            {
                return model.Upsert(forceUpdate);
            }
            return false;
        }

    }
}
