using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using ControlCasaBO;

public partial class administracion_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void login_Authenticate(object sender, AuthenticateEventArgs e)
    {
        //Seccion de autenticacion...
        e.Authenticated=ControlCasaBO.Login.Autenticar(login.UserName, login.Password);
        //FormsAuthentication.RedirectFromLoginPage()
    }
    protected void login_LoggedIn(object sender, EventArgs e)
    {
        //Response.Write("Hola " + Context.User.Identity.Name);
    }
}
