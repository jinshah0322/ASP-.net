using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cookie1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cookie(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Brands");
            string brands = "";
            int count = 0;
            if (CheckBox1.Checked)
            {
                brands += CheckBox1.Text + " ";
                count++;
            }
            if (CheckBox2.Checked)
            {
                brands += CheckBox2.Text + " ";
                count++;
            }
            if (CheckBox3.Checked)
            {
                brands += CheckBox3.Text + " ";
                count++;
            }
            if (CheckBox4.Checked)
            {
                brands += CheckBox4.Text + " ";
                count++;
            }
            cookie.Value = brands;
            Response.Cookies.Add(cookie);
            if (count != 0)
            {
                Label2.Text = Response.Cookies["Brands"].Value;
            }
            else
            {
                Label2.Text = "Select you choice";
            }
        }
    }
}