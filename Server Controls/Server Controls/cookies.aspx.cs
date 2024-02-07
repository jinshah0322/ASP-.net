using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cookies
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cookie(object sender, EventArgs e)
        {
            string name = "Jinay";
            HttpCookie cookie = new HttpCookie("Name");
            cookie.Value = name;
            Response.Cookies.Add(cookie);
            Label1.Text = Response.Cookies["Name"].Value;
        }
    }
}