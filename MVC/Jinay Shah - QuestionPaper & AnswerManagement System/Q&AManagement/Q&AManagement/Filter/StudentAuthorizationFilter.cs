using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Filter
{
    public class StudentAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if ((string)httpContext.Session["Role"] != "Student")
            {
                return false;
            }

            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpStatusCodeResult(403);
        }
    }
}