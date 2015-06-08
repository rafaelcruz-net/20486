using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Filters
{
    public class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            System.Diagnostics.Trace.WriteLine(
                String.Format("Action sendo executado do Controler {0} e Acao {1}",
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                filterContext.ActionDescriptor.ActionName));

            
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
             System.Diagnostics.Trace.WriteLine(
              String.Format("Action Executada do Controler {0} e Acao {1}",
              filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
              filterContext.ActionDescriptor.ActionName));
            base.OnActionExecuted(filterContext);
        }


    }
}