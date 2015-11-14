using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;
using System.Web.Services;

public partial class administracion_Panel : System.Web.UI.Page
{
    [WebMethod()]
    public static byte CambiarEstadoEnVentaCasa(int id, bool enVenta)
    {
        int resultado = Casas.CambiarEstadoEnVenta(id, enVenta);

        if (resultado > 0)
            return 1;
        else
            return 0;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        CasasPanelFilter filter = new CasasPanelFilter();
        filter.Index=0;
        filter.Count=1000;
        gridCasas.DataSource = Casas.ObtenerCasasPanel(filter);
        gridCasas.DataBind();
    }
}
