using System;
using System.Data;
using System.Net;
using System.Web.Mvc;
using Core.Business.Common;
using Core.Web.ViewModel;

namespace Core.Web.Infrastructure
{
    public class Class1 : Controller
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

        protected ActionResult ViewOr404<T>(ViewModelBase<T> viewModel)
            where T : ModelEditBase
        {
            return ViewOr404(viewModel, () => View(viewModel));
        }

        protected ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        protected bool SaveObject<T>(T model, bool forceUpdate = false)
            where T : ModelEditBase
        {
            if (ModelState.IsValid)
            {
                try
                {
                    return model.Upsert(forceUpdate);
                }
                catch (DataException dex)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return false;
        }

        protected ActionResult SaveOr404<T>(ViewModelBase<T> viewModel, bool forceUpdate = false, Func<ActionResult> sucessCallback = null)
            where T : ModelEditBase
        {
            return ViewOr404(viewModel, () =>
            {
                if (SaveObject(viewModel.ModelObject, forceUpdate))
                {
                    return sucessCallback == null ? RedirectToAction("Index") : sucessCallback();
                }
                return View(viewModel);
            });

        }
    }
}
