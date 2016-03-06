using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


namespace RoPaSci
{
    public partial class Downloads : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void download_file(object sender, EventArgs e)
        {
            //Download a document given a path in the server using the HttpResponse class
            try
            {
                LinkButton ln = (LinkButton)sender;

                string remoteUri = "~/downloads/";
                string fileName = ln.Text;
                string strURL = remoteUri + fileName;
                WebClient req = new WebClient();
                HttpResponse responses = HttpContext.Current.Response;
                responses.Clear();
                responses.ClearContent();
                responses.ClearHeaders();
                responses.Buffer = true;                
                responses.AddHeader("Content-Disposition", "attachment;filename=\"" + fileName + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));                
                responses.BinaryWrite(data);                
                responses.End();
            }
            catch (Exception ex)
            {               
               
            }
        }
    }
}