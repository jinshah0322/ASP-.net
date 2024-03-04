using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Q_AManagement.Helpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString DisplayTempData(this HtmlHelper htmlHelper, string key, string successMessage, string successColor,string place)
        {
            if (htmlHelper.ViewContext.TempData[key] != null && htmlHelper.ViewContext.TempData[key].ToString() == successMessage)
            {
                TagBuilder tagBuilder = new TagBuilder("p");
                tagBuilder.MergeAttribute("class", "displayMessage");
                tagBuilder.MergeAttribute("style", $"color:{successColor};text-align:{place}");
                tagBuilder.SetInnerText(successMessage);
                return MvcHtmlString.Create(tagBuilder.ToString());
            }
            return MvcHtmlString.Empty;
        }
    }
}