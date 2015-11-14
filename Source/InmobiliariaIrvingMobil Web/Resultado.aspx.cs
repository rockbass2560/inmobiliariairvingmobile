using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;
using System.Configuration;
using System.Globalization;
using System.Web.UI.HtmlControls;


public partial class Resultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Se crea el filter que ira a base de datos
        CasasFilterBusqueda casaFilter = new CasasFilterBusqueda();

        SetConfigLinkUserControl(casaFilter);

        casaFilter.Ciudad = GetValue("c");
        casaFilter.Colonia = GetValue("col");
        casaFilter.TipoVenta = GetValue("tV");
        casaFilter.TipoInmueble = GetValue("tI");

        casaFilter.PrecioMenor = decimal.Parse(GetValue("pM"),NumberStyles.Currency);
        decimal precioMayor = decimal.Parse(GetValue("pMY"), NumberStyles.Currency);

        //Validacion de precio mayor
        if (precioMayor == Convert.ToDecimal(WebMobilConstant.ObtenerPrecioMenor()))
            precioMayor = decimal.MaxValue;
        else if (precioMayor <= casaFilter.PrecioMenor)
            precioMayor += 1;

        casaFilter.PrecioMayor = precioMayor;

        //Obtenemos las casas, pasando el filtro
        List<CasasResult> casasResult = ControlCasaBO.Casas.ObtenerCasasResultado(casaFilter);

        //Obtener ruta fotografias
        casasResult.ForEach(casa =>
            {
                casa.Fotografia = VirtualPathUtility.ToAbsolute(casa.Fotografia);
            });

        if (casasResult.Count == 0)
        {
            divMensaje.Visible = true;
        }
        if (casasResult.Count < Convert.ToInt32(ConfigurationManager.AppSettings["cantidad"]))
        {
            DisableLinkUserControl();
        }

        repeaterFull.DataSource = casasResult;
        repeaterFull.DataBind();

        repeaterMobil.DataSource = casasResult;
        repeaterMobil.DataBind();
    }

    private void SetConfigLinkUserControl(CasasFilterBusqueda filter)
    {
        ucBackNextTop.SetConfigLinks(filter);
        ucBackNextFooter.SetConfigLinks(filter);
    }

    private void DisableLinkUserControl()
    {
        ucBackNextTop.DisableLinks();
        ucBackNextFooter.DisableLinks();
    }

    private string GetValue(string key)
    {
        string valor;

        if (String.IsNullOrEmpty(Request[key]))
        {
            if (Session[key] != null)
            {
                if (Session[key].ToString().Equals("-1"))
                    valor = null;
                else
                    valor = Session[key].ToString();
            }
            else
            {
                valor = null;
                Session[key] = valor;
            }
        }
        else
        {
            if (Request[key].Equals("-1"))
            {
                valor = null;
                Session[key] = "-1";
            }
            else
            {
                valor = Request[key];
                Session[key] = valor;
            }
        }
        

        return valor;
    }
}
