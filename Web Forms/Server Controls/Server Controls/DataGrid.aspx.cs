using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Server_Controls
{
    public partial class DataGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("Email");
            dt.Rows.Add("1", "Jinay", "abc@gmail.com");
            dt.Rows.Add("2", "ABC", "xyz@gmail.com");
            dt.Rows.Add("1", "XYZ", "pqr@gmail.com");
            DataGrid1.DataSource= dt;
            DataGrid1.DataBind();
        }
    }
}