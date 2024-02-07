using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Download_File
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void HandleDownload(object server, EventArgs e)
        {
            string filepath = "C:\\Users\\BAPS\\Desktop\\Jinay Shah - STTL\\HTML-CSS\\JinayShah_HTML_20Questions.txt";
            FileInfo file = new FileInfo(filepath);
            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "text/plain";
                Response.Flush();
                Response.TransmitFile(file.FullName);
                Response.End();
            }
            else
            {
                Label1.Text = "File not found";
            }
        }
    }
}