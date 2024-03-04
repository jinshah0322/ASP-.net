using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace fileupload
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void HandleRequest(object sender, EventArgs e)
        {
            string text = "";
            if (FileUpload1.PostedFile != null && FileUpload1.PostedFile.ContentLength > 0)
            {
                string fileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string saveLocation = Server.MapPath("upload") + "\\" + fileName;
                try
                {
                    FileUpload1.PostedFile.SaveAs(saveLocation);
                    text = $"{fileName} uploaded successfully";
                }
                catch (Exception ex)
                {
                    text = "Error:" + ex.Message;
                }
            }
            else
            {
                text = "Please select a file to upload";
            }
            Label1.Text = text;
        }
    }
}