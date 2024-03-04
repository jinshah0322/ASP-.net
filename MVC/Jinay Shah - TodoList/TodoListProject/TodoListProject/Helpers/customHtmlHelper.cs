using System.Web.Mvc;
using System.Web;

namespace TodoListProject.Helpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString DisplayTempData(this HtmlHelper htmlHelper, string key, string successMessage, string successColor )
        {
            if (htmlHelper.ViewContext.TempData[key] != null && htmlHelper.ViewContext.TempData[key].ToString() == successMessage)
            {
                TagBuilder tagBuilder = new TagBuilder("p");
                tagBuilder.MergeAttribute("class", "displayMessage");
                tagBuilder.MergeAttribute("style", $"color:{successColor};");
                tagBuilder.SetInnerText(successMessage);
                return MvcHtmlString.Create(tagBuilder.ToString());
            }
            return MvcHtmlString.Empty;
        }
    }
}