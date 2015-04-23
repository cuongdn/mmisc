using System;
using System.Data;
using System.Net;
using System.Web.Mvc;
using Core.Business.Common;
using Core.Web.ViewModel;

namespace Core.Web.Infrastructure
{
    public abstract class BaseController : Controller
    {
        protected ActionResult ViewPreviewOr404<T>(T modelObject)
            where T : ModelBase
        {
            var viewModel = new ViewModelPreview<T>
            {
                ModelObject = modelObject
            };
            return ViewOr404(viewModel, () => View(viewModel));
        }

        protected ActionResult ViewPreviewOr404<T>(T modelObject, Func<ActionResult> renderView)
            where T : ModelBase
        {
            var viewModel = new ViewModelPreview<T>
            {
                ModelObject = modelObject
            };
            return ViewOr404(viewModel, renderView);
        }

        protected ActionResult ViewEditOr404<T>(T modelObject, Func<ActionResult> renderView)
            where T : ModelEditBase
        {
            var viewModel = new ViewModelEdit<T>
            {
                ModelObject = modelObject
            };

            return ViewOr404(viewModel, renderView);
        }

        protected ActionResult ViewEditOr404<T>(T modelObject)
            where T : ModelEditBase
        {
            var viewModel = new ViewModelEdit<T>
            {
                ModelObject = modelObject
            };

            return ViewOr404(viewModel, () => View(viewModel));
        }

        protected ActionResult ViewOr404<T>(IViewModel<T> viewModel, Func<ActionResult> renderView)
            where T : ModelBase
        {
            if (!viewModel.Found)
            {
                return HttpNotFound();
            }
            return renderView();
        }

        protected ActionResult ViewOr404<T>(IViewModel<T> viewModel)
            where T : ModelBase
        {
            return ViewOr404(viewModel, () => View(viewModel));
        }

        protected ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        protected virtual bool SaveObject<T>(T model, bool forceUpdate = false)
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
                    //TODO: Log the error here.
                    ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return false;
        }

        protected ActionResult SaveOr404<T>(ViewModelEdit<T> viewModel, bool forceUpdate = false, Func<ActionResult> sucessCallback = null)
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

        protected ActionResult ViewDelete<T>(int? id, bool? saveChangesError, T modelObject)
            where T : ModelEditBase
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var viewModel = new ViewModelEdit<T>
            {
                ModelObject = modelObject
            };
            return ViewConfirmDeleteOr404(viewModel, saveChangesError);
        }



        protected virtual bool DeleteObject<T>(T model)
            where T : ModelEditBase
        {
            try
            {
                return !model.IsNew && model.Delete();
            }
            catch (DataException dex)
            {
                //TODO: Log the error here.
                return false;
            }
        }

        protected ActionResult ViewConfirmDeleteOr404<T>(IViewModel<T> viewModel, bool? saveChangesError)
           where T : ModelEditBase
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            return ViewOr404(viewModel);
        }

        protected ActionResult DeleteOr404<T>(int id, ViewModelEdit<T> viewModel)
            where T : ModelEditBase
        {
            if (!viewModel.Found)
            {
                return HttpNotFound();
            }

            if (DeleteObject(viewModel.ModelObject))
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete", new { id, saveChangesError = true });
        }
    }
}
