using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControlCasaBO;
using System.Configuration;
using System.Globalization;
using System.Web.Services;
using System.Web.SessionState;
using System.IO;

public partial class Catalogo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Se verifica si es una peticiona (ajax), para eliminar el archivo temporal de presentacion de la imagen
        string eliminarSesion = Request["eS"];
        if (Session["fotografiaTemp"]!=null && !String.IsNullOrEmpty(eliminarSesion) && eliminarSesion.Equals("t"))
        {
            /*string filePath = Server.MapPath(Session["fotografiaTemp"].ToString());
            File.Delete(filePath);*/
        }
        if (!Page.IsPostBack)
        {
            //Cargamos los datos para los combos
            CargarCombos();

            string stringAction = Request["action"];
            if (!String.IsNullOrEmpty(stringAction))
                Session["action"] = stringAction;
            else
                stringAction = Session["action"].ToString();
            
            hiddenAction.Value = stringAction;
            Actions action = (Actions)(Enum.Parse(typeof(Actions), stringAction, true));

            switch (action)
            {
                case Actions.INSERT:
                    botonAlta.Visible = true;
                    botonModificar.Visible = false;

                    hdnEnVenta.Value = Boolean.TrueString;
                    break;
                case Actions.EDIT:
                    botonAlta.Visible = false;
                    botonModificar.Visible = true;

                    //Obtenemos el id de la casa a modificar
                    int id = Convert.ToInt32(Request["id"]);
                    CasaCatalogoResult casa = Casas.ObtenerCasa(id);

                    CargarDatos(casa);

                    break;
                default:
                    //Sera alta la opcion default
                    botonAlta.Visible = true;
                    botonModificar.Visible = false;

                    break;
            }
        }
    }

    //Metodo que pinta una Casa Result en los Controles Web
    private void CargarDatos(CasaCatalogoResult casa)
    {
        textID.Text = casa.ID.ToString();
        textCalle.Text = casa.Calle;
        textNumero.Text = casa.Numero;
        textCodigoPostal.Text = casa.CodigoPostal;
        selectColonia.SetValue(casa.Colonia);
        selectCiudad.SetValue(casa.Ciudad);

        textPrecio.Text = casa.Precio.ToString();
        selectTipoInmueble.SetValue(casa.TipoInmueble);
        selectTipoVenta.SetValue(casa.TipoTransaccion);
        textNiveles.Text = casa.Niveles.ToString();
        textRecamaras.Text = casa.Recamaras.ToString();
        textCochera.Text = casa.Cochera.ToString();
        textBanos.Text = casa.Baños.ToString();
        textEdad.Text = casa.Edad.ToString();

        textTerreno.Text = casa.Terreno.ToString();
        textConstruccion.Text = casa.Construccion.ToString();
        textFrente.Text = casa.Frente.ToString();
        textFondo.Text = casa.Fondo.ToString();
        selectForma.SetValue(casa.Forma);

        checkEsquina.Checked = casa.Esquina;
        checkJardin.Checked = casa.Jardin;
        checkAlberca.Checked = casa.Alberca;
        checkEstudio.Checked = casa.Estudio;
        //Transformar url
        fotografiaCasa.ImageUrl = VirtualPathUtility.ToAbsolute(casa.Fotografia);
        textDescripcion.Text = casa.Descripcion;

        hiddenPropietario.Value = casa.Propietario;
        hiddenTelefono.Value = casa.Telefono;

        hdnEnVenta.Value = casa.EnVenta.ToString();
    }

    //Carga de combos
    private void CargarCombos()
    {
        selectColonia.BindCombo(Colonia.GetColoniasAll());

        selectCiudad.BindCombo(Ciudad.GetCiudadesAll());

        selectTipoInmueble.BindCombo(TipoInmueble.GetTipoInmueblesAll());

        selectTipoVenta.BindCombo(TipoVenta.GetTipoVentaAll());

        selectForma.BindCombo(Forma.GetFormaAll());

    }

    //Eventos para el click del boton de accion (Modificar o Agregar)
    protected void botonModificar_Click(object sender, EventArgs e)
    {
        //Logica cuando sea una modificacion, el id se extrae de la caja de texto ID
        CasaFilter filter = new CasaFilter();
        Casas casasBO = new Casas();

        try
        {
            casasBO.OpenTransaction();

            filter.ID = Convert.ToInt32(textID.Text);

            UpdateCasa(filter, casasBO);

            casasBO.Commit();

            string mensaje = String.Format("Se a modificado la casa con id : {0}", filter.ID);

            Response.Redirect("resultado.aspx?mensaje=" + mensaje, false);
        }
        catch (Exception)
        {
            casasBO.RollBack();
        }
    }

    protected void ActionAgregar_Click(object sender, EventArgs e)
    {
        //Logica para agregar casas cuando sea Alta, se crea una casa Dummy en base de datos para obtener el id previamente
        CasaFilter filter = new CasaFilter();
        Casas casasBO = new Casas();

        try
        {
            casasBO.OpenTransaction();

            filter.ID = casasBO.GetID();

            UpdateCasa(filter,casasBO);

            //Se realiza un commit de todas las operaciones
            casasBO.Commit();

            string mensaje = String.Format("Se a dado de alta la casa con id : {0}", filter.ID);
            
            Response.Redirect("resultado.aspx?mensaje=" + mensaje, true);
        }
        catch
        {
            casasBO.RollBack();
        }
    }

    private void UpdateCasa(CasaFilter filter, Casas casasBO)
    {
        filter.Alberca = checkAlberca.Checked;
        filter.Baños = Convert.ToSingle(textBanos.Text);
        filter.Calle = textCalle.Text;
        filter.Ciudad = Convert.ToInt32(selectCiudad.SelectedValue);
        filter.Cochera = Convert.ToInt32(textCochera.Text);
        filter.CodigoPostal = textCodigoPostal.Text;
        filter.Colonia = Convert.ToInt32(selectColonia.SelectedValue);
        filter.Construccion = Convert.ToSingle(textConstruccion.Text);
        filter.Descripcion = textDescripcion.Text;
        filter.Esquina = checkEsquina.Checked;
        filter.Estudio = checkEstudio.Checked;
        filter.Fondo = Convert.ToSingle(textFondo.Text);
        filter.Forma = Convert.ToInt32(selectForma.SelectedValue);

        filter.Fotografia = GuardarFotografia(filter.ID);

        filter.Frente = Convert.ToSingle(textFrente.Text);
        filter.Jardin = checkJardin.Checked;
        filter.Niveles = Convert.ToInt32(textNiveles.Text);
        filter.Numero = textNumero.Text;
        filter.Precio = Convert.ToSingle(textPrecio.Text, new CultureInfo("es-MX").NumberFormat);
        filter.Recamaras = Convert.ToInt32(textRecamaras.Text);

        filter.Telefono = hiddenTelefono.Value;
        filter.Propietario = hiddenPropietario.Value;        

        filter.Terreno = Convert.ToSingle(textTerreno.Text);
        filter.TipoInmueble = Convert.ToInt32(selectTipoInmueble.SelectedValue);
        filter.TipoTransaccion = Convert.ToInt32(selectTipoVenta.SelectedValue);

        filter.EnVenta = Convert.ToBoolean(hdnEnVenta.Value);

        casasBO.UpdateCasa(filter);
    }

    private string GuardarFotografia(int id)
    {
        string result = "~/images/casas/sinimagen.jpg";
        
        if (uploadFotografia.HasFile)
        {
            result = String.Format("~/images/casas/{0}.jpg", id);

            string fileName = Server.MapPath(result);

            WebMobilConstant.SaveImage(uploadFotografia.FileBytes, fileName);

            //uploadFotografia.SaveAs(fileName);
            
        }
        
        return result;
    }

    protected void uploadFotografia_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        const string carpetaTemporal = "~/temp";

        if (uploadFotografia.HasFile)
        {
            string nombreArchivo = Guid.NewGuid().ToString("N") + ".jpg";
            string fileName = "/" + nombreArchivo;
            string folder = Server.MapPath(carpetaTemporal);

            //uploadFotografia.SaveAs(String.Format("{0}{1}", folder, fileName));
            WebMobilConstant.SaveImage(uploadFotografia.FileBytes, String.Format("{0}{1}", folder, fileName));

            string pathFileVirtual = String.Format("{0}{1}", VirtualPathUtility.ToAbsolute(carpetaTemporal), fileName);
            
            //ScriptManager.RegisterStartupScript(this, GetType(), "ChangeImage", "top.document.getElementById('fotografiaCasa').src='" + pathFileVirtual + "';", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "ChangeImage", "top.chargeImage('" + pathFileVirtual + "','"+ nombreArchivo +"');", true);
        }
    }
}
