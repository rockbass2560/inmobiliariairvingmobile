using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Pierden valores sin viewstate
        if (!Page.IsPostBack)
        {
            precioMenor.Attributes["min"] = WebMobilConstant.ObtenerPrecioMenor();
            precioMayor.Attributes["min"] = WebMobilConstant.ObtenerPrecioMenor();
            precioMenor.Attributes["max"] = WebMobilConstant.ObtenerPrecioMayor();
            precioMayor.Attributes["max"] = WebMobilConstant.ObtenerPrecioMayor();
            precioMenor.Attributes["step"] = WebMobilConstant.ObtenerStep();
            precioMayor.Attributes["step"] = WebMobilConstant.ObtenerStep();
            precioMenor.Text = WebMobilConstant.ObtenerPrecioMenor();
            precioMayor.Text = WebMobilConstant.ObtenerPrecioMayor();

            List<TipoVentaResult> listaTipoVenta = TipoVenta.GetTipoVenta();
            listaTipoVenta.Insert(0, new TipoVentaResult { ID = -1, Descripcion = "Operacion" });
            selectComprar.DataSource = listaTipoVenta;
            selectComprar.DataTextField = TipoVentaConstant.Descripcion;
            selectComprar.DataValueField = TipoVentaConstant.ID;
            selectComprar.DataBind();

            List<TipoInmuebleResult> listaTipoInmueble = new TipoInmueble().GetTipoInmuebles();
            listaTipoInmueble.Insert(0, new TipoInmuebleResult { ID = -1, Descripcion = "Tipo de Inmueble" });
            selectTipoInmueble.DataSource = listaTipoInmueble;
            selectTipoInmueble.DataTextField = TipoInmuebleConstant.DESCRIPCION;
            selectTipoInmueble.DataValueField = TipoInmuebleConstant.ID;
            selectTipoInmueble.DataBind();

            List<CiudadResult> listaCiudades = Ciudad.GetCiudades();
            listaCiudades.Insert(0, new CiudadResult { ID = -1, Descripcion = "Ciudad" });
            selectCiudad.DataSource = listaCiudades;
            selectCiudad.DataTextField = CiudadConstant.DESCRIPCION;
            selectCiudad.DataValueField = CiudadConstant.ID;
            selectCiudad.DataBind();

            List<ColoniaResult> listaColonias = Colonia.GetColonias();
            listaColonias.Insert(0, new ColoniaResult { ID = -1, Descripcion = "Colonia" });
            selectColonia.DataSource = listaColonias;
            selectColonia.DataTextField = ColoniaConstant.DESCRIPCION;
            selectColonia.DataValueField = ColoniaConstant.ID;
            selectColonia.DataBind();
        }
    }
    protected void buttonBusqueda_Click(object sender, EventArgs e)
    {
        Response.Redirect(
            String.Format(
            "Resultado.aspx?tV={0}&tI={1}&c={2}&col={3}&pM={4}&pMY={5}",
            selectComprar.SelectedValue,
            selectTipoInmueble.SelectedValue,
            selectCiudad.SelectedValue,
            selectColonia.SelectedValue,
            precioMenor.Text,
            precioMayor.Text
            ),true);
    }
}
