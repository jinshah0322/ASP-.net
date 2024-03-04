using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace button
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void clickHandler(object sender, EventArgs e)
        {
            Label1.Text = "Button has been clicked";
        }
    }
}