using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contacto : System.Web.UI.Page
{
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        //Envio de email
        try
        {
            Email.EnviarEmail(textNombre.Text, textEmail.Text, textTelefono.Text, textMensaje.Text);
        }
        catch (Exception)
        {
            divMensaje.InnerHtml = "Lo sentido a ocurrido un error durante el envio de email<br>Porfavor intentelo mas tarde";
        }
        divMensaje.Visible = true;
        divElementos.Visible = false;
    }
}
