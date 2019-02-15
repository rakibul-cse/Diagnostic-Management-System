using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Diagnostic_Center
{
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           
            string a = "";
            string FilePath = "";

            if (a == "Report_GISApplication_Final" | a == "User_Manual_GISApp")
            {
                Response.ContentType = "Application/vnd.ms-word";               
                FilePath = MapPath("Result/" + a + ".doc");
                FileInfo file = new FileInfo(FilePath);
                Response.AddHeader("Content-Disposition", "inline; filename=\"" + file.FullName + "\"");
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.TransmitFile(file.FullName);
            }
            else
            {                
                byte[] FileBuffer = (byte[])Session["rptbyte"];
                if (FileBuffer != null)
                {
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-length", FileBuffer.Length.ToString());
                    Response.BinaryWrite(FileBuffer);
                }

            }
        }
    }
}