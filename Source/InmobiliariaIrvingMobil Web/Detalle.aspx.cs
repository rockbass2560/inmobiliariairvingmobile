using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;
using System.Configuration;

public partial class Detalle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string formatPrice = ConfigurationManager.AppSettings[WebMobilConstant.FORMATPRICE];

        //Se setean valores personales como telefono e email
        email.HRef = String.Format("mailto:{0}",ConfigurationManager.AppSettings["email"]);
        telefono.HRef = String.Format("tel:{0}", ConfigurationManager.AppSettings["telefono"]);
        linkTel.HRef = String.Format("tel:{0}", ConfigurationManager.AppSettings["telefono"]);
        ltrTelefono.Text = ConfigurationManager.AppSettings["telefono"];

        //Se obtiene la casa y se imprime valores
        int id=Convert.ToInt32(Request.QueryString["ID"]);
        CasasResultById casa = Casas.ObtenerCasasById(id);

        //Se setea la seccion de compatir
        UriBuilder uri=new UriBuilder(Uri.UriSchemeHttp,Request.Url.Host,80,"Detalle.aspx","?ID="+id.ToString());
        linkFacebook.HRef += String.Format("Se {0} {1}, mirala en el siguiente link {2}",casa.TipoTransaccion,casa.TipoInmueble,uri.ToString());
        linkTwitter.HRef += String.Format("Se {0} {1}, mirala en el siguiente link {2}", casa.TipoTransaccion, casa.TipoInmueble, uri.ToString());
        linkCorreo.HRef += String.Format("Se {0} {1}, mirala en el siguiente link {2}", casa.TipoTransaccion, casa.TipoInmueble, uri.ToString());

        ltrVendedor.Text = ConfigurationManager.AppSettings["vendedor"];

        ltrBaños.Text = casa.Baños.ToString();
        ltrCalle.Text = casa.Calle;
        ltrCiudad.Text = casa.Ciudad;
        ltrCiudad2.Text = casa.Ciudad;
        ltrCodigoPostal.Text = casa.CodigoPostal;
        ltrCodigoPostal2.Text = casa.CodigoPostal;
        ltrColonia.Text = casa.Colonia.ToUpper();
        ltrColonia2.Text = casa.Colonia;
        ltrConstruccion.Text = casa.Construccion.ToString();
        ltrID.Text = casa.ID.ToString();
        ltrNiveles.Text = casa.Niveles.ToString();
        ltrNumero.Text = casa.Numero;
        ltrPrecio.Text = casa.Precio.ToString(formatPrice);
        ltrPrecio2.Text = casa.Precio.ToString(formatPrice);
        ltrTerreno.Text = casa.Terreno.ToString();
        ltrTipoInmueble.Text = casa.TipoInmueble;
        ltrTipoInmueble2.Text = casa.TipoInmueble;
        ltrTipoTransaccion.Text = casa.TipoTransaccion;
        fotografia.Src = casa.Fotografia;
    }
}
