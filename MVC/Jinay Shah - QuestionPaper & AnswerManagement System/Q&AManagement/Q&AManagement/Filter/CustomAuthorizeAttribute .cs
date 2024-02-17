using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class CustomAuthorizeAttribute : AuthorizeAttribute
{
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        return httpContext.Session["UserID"] != null;
    }

    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary
            {
                { "controller", "User" },
                { "action", "Login" }
            });
    }
}
