using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using System.IO;

/// <summary>
/// Descripción breve de Configuracion
/// </summary>
public class Configuracion
{
    public int PositionCredito { get; set; }
    public int PositionCalle { get; set; }
    public int PositionColonia { get; set; }
    public int PositionNombre { get; set; }

    private static Configuracion instance;

    private string rutaFisica;

    private static string RUTA = "~/generadorinvitaciones/Resources/Configuracion.xml"; 

    public void SaveConfiguration()
    {
        XmlSerializer serializer = new XmlSerializer(this.GetType());

        using (StreamWriter writer = new StreamWriter(rutaFisica))
        {
            serializer.Serialize(writer, this);
        }
    }

    protected void LoadConfiguration()
    {
        this.rutaFisica = HttpContext.Current.Server.MapPath(RUTA);

        XmlSerializer serializer = new XmlSerializer(this.GetType());
        using (StreamReader reader = new StreamReader(rutaFisica))
        {
            Configuracion configuracion = (Configuracion)serializer.Deserialize(reader);

            this.PositionCalle = configuracion.PositionCalle;
            this.PositionColonia = configuracion.PositionColonia;
            this.PositionCredito = configuracion.PositionCredito;
            this.PositionNombre = configuracion.PositionNombre;
        }
    }

    public static Configuracion GetInstance()
    {
        if (instance == null)
        {
            instance = new Configuracion();
            instance.LoadConfiguration();
        }
        return instance;
    }

    protected Configuracion()
    {
    }
}