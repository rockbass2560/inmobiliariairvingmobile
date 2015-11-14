using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Configuration;
using System.Net;

public class Email
{
    public static void EnviarEmail(string nombre, string email, string telefono, string mensaje)
    {
        MailMessage mailMessage = new MailMessage();
        SmtpClient client = new SmtpClient();
        try
        {
            mailMessage.To.Add(new MailAddress(ConfigurationManager.AppSettings[WebMobilConstant.EMAILCLIENT]));
            mailMessage.Subject = "Se han enviado los siguientes datos de contacto de la pagina Inmobiliaria Irving Mobil";
            mailMessage.Body = String.Format(@"Se han enviado los siguiente datos de la pagina de Inmobiliaria Irving Mobil<br>Nombre: {0}<br>Telefono: {1}<br>Mensaje: {2}", nombre, telefono, mensaje);
            mailMessage.IsBodyHtml = true;

            client.Send(mailMessage);
        }
        finally
        {
            mailMessage.Dispose();
            client.Dispose();
        }
    }
}
