using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class remover : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string file = Request["file"];

        if (!String.IsNullOrEmpty(file))
        {
            string folder = Server.MapPath("../temp");

            File.Delete(folder + "/" + file);
        }
    }
}