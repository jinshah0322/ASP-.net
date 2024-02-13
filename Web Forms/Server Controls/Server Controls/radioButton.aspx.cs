using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace radioButton
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                Label1.Text = "Your gender is " + RadioButton1.Text;
            }
            else
            {
                Label1.Text = "Your gender is " + RadioButton2.Text;
            }
        }
    }
}