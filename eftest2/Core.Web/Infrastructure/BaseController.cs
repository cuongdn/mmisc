using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Mvc;
using Core.Business.Common;
using Core.Common.Exceptions;
using Core.Logging;
using Core.Web.Common;
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
                return NotFound();
            }
            return renderView();
        }

        protected ActionResult ViewOr404<T>(IViewModel<T> viewModel)
            where T : ModelBase
        {
            return ViewOr404(viewModel, () => View(viewModel));
        }

        protected virtual ActionResult BadRequest()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        protected virtual ActionResult NotFound()
        {
            return HttpNotFound();
        }

        protected virtual bool SaveObject<T>(T model, bool forceUpdate = false)
            where T : ModelEditBase
        {
            if (ModelState.IsValid)
            {
                var result = DoSave(() => model.Upsert(forceUpdate));
                if (result == ESaveResult.Success) return true;

                ModelState.AddModelError(string.Empty, GetMessageFromResult(result));
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

        protected ActionResult ViewDeleteOr404<T>(int? id, T modelObject)
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
            return ViewDeleteOr404(viewModel);
        }

        protected virtual bool DeleteObject<T>(T model)
            where T : ModelEditBase
        {
            var result = DoSave(model.Delete);
            if (result == ESaveResult.Success) return true;
            TempData[WebConstants.ErrorMessage] = GetMessageFromResult(result);
            return false;
        }

        protected virtual ESaveResult DoSave(Func<bool> save)
        {
            try
            {
                var result = save();
                return result ? ESaveResult.Success : ESaveResult.NoAffectedRows;
            }
            catch (ConcurrencyException ex)
            {
                Logger.Default.Error("Business Concurrency Exception", ex);
                return ESaveResult.ConcurrencyError;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Logger.Default.Error("Db Update Concurrency Exception", ex);
                return ESaveResult.ConcurrencyError;
            }
            catch (DataException ex)
            {
                Logger.Default.Error("Data Exception", ex);
            }
            catch (AppException ex)
            {
                Logger.Default.Error("Application Exception", ex);
            }
            catch (Exception ex)
            {
                Logger.Default.Error("General Exception", ex);
            }
            return ESaveResult.Error;
        }

        protected virtual string GetMessageFromResult(ESaveResult result)
        {
            switch (result)
            {
                case ESaveResult.NoAffectedRows:
                case ESaveResult.Error:
                    return "Unable to save changes. Try again, and if the problem persists, see your system administrator.";
                case ESaveResult.ConcurrencyError:
                    return "Concurrent update error.";
                default:
                    return string.Empty;
            }
        }

        protected ActionResult ViewDeleteOr404<T>(IViewModel<T> viewModel, bool? saveChangesError = null)
           where T : ModelEditBase
        {
            if (saveChangesError.GetValueOrDefault())
            {
                if (!viewModel.Found)
                {
                    // Someone deleted this object
                    return RedirectToAction("Index");
                }
            }

            return ViewOr404(viewModel);
        }

        protected ActionResult DeleteOr404<T>(int id, ViewModelEdit<T> viewModel)
            where T : ModelEditBase
        {
            if (!viewModel.Found)
            {
                return NotFound();
            }
            if (DeleteObject(viewModel.ModelObject))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id, saveChangesError = true });
        }
    }
}
