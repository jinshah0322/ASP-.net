using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace calander
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void dataChanged(object sender, EventArgs e)
        {
            ShowData.Text = "You selected:" + Calender1.SelectedDate.ToString();
        }
    }
}