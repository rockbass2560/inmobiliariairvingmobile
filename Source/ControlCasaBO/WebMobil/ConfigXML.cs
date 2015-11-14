using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Web;
using System.Configuration;
using System.IO;

namespace ControlCasaBO.WebMobil
{
    [XmlRoot("Formatos")]
    public class ConfigXML
    {
        public static ConfigXML GetConfigXml()
        {
            string rutaAbsoluta = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["pathXml"]);
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigXML));
            return serializer.Deserialize(File.OpenRead(rutaAbsoluta)) as ConfigXML;            
        }
        [XmlArray("Formato"), XmlArrayItem("add", Type = typeof(Add))]
        public Formato[] Formatos { get; set; }
    }
    [XmlType("Formato")]
    public class Formato
    {
        [XmlAttribute("Result")]
        public string Result { get; set; }
    }
    [XmlType("add")]
    public class Add
    {
        [XmlElement("propiedad")]
        public string Propiedad { get; set; }

        [XmlElement("key")]
        public string Key { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
