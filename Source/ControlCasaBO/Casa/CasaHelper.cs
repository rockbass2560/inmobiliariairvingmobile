using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Web;
using System.Configuration;

namespace ControlCasaBO
{
    internal static class CasaHelper
    {
        internal static void FormatProperty<T>(IList<T> casas)
        {
            string nameResult=typeof(T).Name;
            string rutaArchivo = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebMobilConstant.ARCHIVOFORMATO]);
            //Obtenemos el Formato del correspondiente result (de haber uno)
            XmlDocument document = new XmlDocument();
            document.Load(rutaArchivo);

            if (document.SelectNodes(String.Format("//Formato[@result='{0}']", nameResult)).Count > 0)
            {
                XmlNode nodeFormat = document.SelectNodes(String.Format("//Formato[@result='{0}']", nameResult))[0];
                foreach (XmlNode xmlElement in nodeFormat.SelectNodes("//Elemento"))
                {
                    string namePropiedad = xmlElement.Attributes["propiedad"].Value;
                    string clavePropiedad = xmlElement.Attributes["clave"].Value;
                    string valorPropiedad = xmlElement.Attributes["valor"].Value;

                    casas.ToList().ForEach(
                        casa =>
                        {
                            Type typeCasa = casa.GetType();
                            PropertyInfo info = typeCasa.GetProperty(namePropiedad);
                            if (info.GetValue(casa,null).Equals(clavePropiedad))
                            {
                                info.SetValue(casa,valorPropiedad,null);
                            }
                        }
                   );
                }
            }
        }
        internal static void FormatProperty<T>(T casa)
        {
            string nameResult = typeof(T).Name;
            string rutaArchivo = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[WebMobilConstant.ARCHIVOFORMATO]);
            //Obtenemos el Formato del correspondiente result (de haber uno)
            XmlDocument document = new XmlDocument();
            document.Load(rutaArchivo);

            if (document.SelectNodes(String.Format("//Formato[@result='{0}']", nameResult)).Count > 0)
            {
                Type typeCasa = casa.GetType();
                XmlNode nodeFormat = document.SelectNodes(String.Format("//Formato[@result='{0}']", nameResult))[0];
                foreach (XmlNode xmlElement in nodeFormat.SelectNodes("//Elemento"))
                {
                    string namePropiedad = xmlElement.Attributes["propiedad"].Value;
                    string clavePropiedad = xmlElement.Attributes["clave"].Value;
                    string valorPropiedad = xmlElement.Attributes["valor"].Value;
                    
                    PropertyInfo info = typeCasa.GetProperty(namePropiedad);
                    if (info.GetValue(casa, null).Equals(clavePropiedad))
                    {
                        info.SetValue(casa, valorPropiedad, null);
                    }
                }
            }
        }
    }
}
