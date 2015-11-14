using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;

public partial class administracion_CatalogoGeneral : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string catalogo = Request.Params["catalogo"];

        switch (catalogo)
        {
            case Catalogos.COLONIA:
                repeater.DataSource = Colonia.GetColoniasAll();
                break;
            default:
                
                break;
        }
        
        repeater.DataBind();
    }
}