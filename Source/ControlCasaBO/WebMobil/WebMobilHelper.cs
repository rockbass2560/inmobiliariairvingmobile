using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Configuration;
using System.Xml;
using ControlCasaBO.WebMobil;

namespace ControlCasaBO
{
    public class WebMobilHelper
    {
        private static readonly string imagesPath = System.Configuration.ConfigurationManager.AppSettings[WebMobilConstant.CARPETAIMAGENES];

        public static string GetImagePath(int id)
        {
            string rutaRelativa = String.Format(imagesPath, id);

            string rutaAbsoluta = HttpContext.Current.Server.MapPath(rutaRelativa);

            if (File.Exists(rutaAbsoluta))
                return rutaRelativa;
            //Sin imagen en caso de no existir
            return String.Format(imagesPath, WebMobilConstant.SINIMAGEN);
        }
        internal static void SetFormat<T>(IList<T> obj)
        {
            //Tomamos la ubicacion del archivo xml del web.config
            string result = obj[0].GetType().Name;

            ConfigXML config = ConfigXML.GetConfigXml();

        }
    }
}
