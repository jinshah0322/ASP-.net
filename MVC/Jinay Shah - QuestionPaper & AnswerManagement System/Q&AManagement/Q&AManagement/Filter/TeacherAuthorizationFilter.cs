using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Filter
{
    public class TeacherAuthorizationFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if ((string)httpContext.Session["Role"] != "Teacher")
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
