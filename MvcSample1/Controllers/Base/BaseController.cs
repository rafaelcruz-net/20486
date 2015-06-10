using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers.Base
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.Menu = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToUpper();
            base.OnActionExecuted(filterContext);
        }

    }
}
