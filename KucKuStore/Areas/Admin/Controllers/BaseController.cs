using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KucKuStore.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["taikhoan"];
            if(session == null)
            {
                filterContext.Result = new RedirectToRouteResult( 
                    new RouteValueDictionary(new { controller = "Login", action = "DangNhap1", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }
    }
}