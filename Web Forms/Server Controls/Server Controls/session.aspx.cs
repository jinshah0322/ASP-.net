using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace session
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void login(object sender, EventArgs e)
        {
            if (TextBox2.Text == "root")
            {
                Session["Email"] = TextBox1.Text;
                if (Session["Email"] != null)
                {
                    Label1.Text = "Email stored to session :" + Session["Email"].ToString();
                }
            }
            else
            {
                Label1.Text = "Wrong Password";
            }
        }
    }
}