using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;
using System.Configuration;

public partial class UserControl_ButtonsBackNext : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {        
    }

    public void DisableLinks()
    {
        linkSiguiente.AddClass("ui-disabled");
    }

    public void SetConfigLinks(CasasFilterBusqueda filter)
    {
        string url = Request.Url.GetLeftPart(UriPartial.Path);
        int cantidad = 0;
        int indice = 0;

        if (!string.IsNullOrEmpty(Request["i"]))
        {
            //Logica para la paginacion
            cantidad = Convert.ToInt32(ConfigurationManager.AppSettings["cantidad"]);
            indice = Convert.ToInt32(Request["i"]);
            filter.Index = indice;
            filter.Count = indice + cantidad;

            //Logica para los link
            linkAnterior.HRef = String.Format("{0}?i={1}", url, indice - cantidad);
            linkSiguiente.HRef = String.Format("{0}?i={1}", url, indice + cantidad);
        }
        else
        {
            //Logica para la paginacion
            cantidad = Convert.ToInt32(ConfigurationManager.AppSettings["cantidad"]);
            filter.Index = indice;
            filter.Count = indice + cantidad;

            //Logica para los link
            linkAnterior.HRef = String.Format("{0}?i={1}", url, indice);
            linkSiguiente.HRef = String.Format("{0}?i={1}", url, indice + cantidad);
        }

        if (indice == 0)
        {
            linkAnterior.AddClass("ui-disabled");
        }
    }
}