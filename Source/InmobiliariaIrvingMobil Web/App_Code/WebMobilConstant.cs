using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

    /// <summary>
    /// Clase que contiene constantes y metodos de ayuda o informacion que solo se utilizan en
    /// la pagina web mobil
    /// </summary>
public static partial class WebMobilConstant
{
    public const string PRECIOMENOR = "precioMenor";
    public const string PRECIOMAYOR = "precioMayor";
    public const string FORMATPRICE = "formatPrice";
    public const string STEP = "step";
    public const string EMAILCLIENT = "email";
    public const string FOLDERIMAGES = "folderImages";
    public const string FOLDERCASAS = "folderCasas";

    public static string ObtenerPrecioMenor()
    {
        return ConfigurationManager.AppSettings[PRECIOMENOR];
    }
    public static string ObtenerPrecioMayor()
    {
        return ConfigurationManager.AppSettings[PRECIOMAYOR];
    }
    public static string ObtenerStep()
    {
        return ConfigurationManager.AppSettings[STEP];
    }
    public static void SaveImage(byte[] bytes,string path)
    {
        Bitmap imagen = (Bitmap)System.Drawing.Image.FromStream(new MemoryStream(bytes));
        MemoryStream stream = new MemoryStream();
        try
        {
            imagen.SetResolution(400, 300);
            FileStream file = new FileStream(path, FileMode.OpenOrCreate);
            imagen.Save(stream,ImageFormat.Jpeg);
            stream.WriteTo(file);
            file.Close();
        }
        finally
        {
            stream.Dispose();
        }
        //GC.ReRegisterForFinalize(imagen);
    }
}

