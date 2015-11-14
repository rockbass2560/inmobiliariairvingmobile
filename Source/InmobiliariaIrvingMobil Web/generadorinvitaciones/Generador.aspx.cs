using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Excel;
using ProcessData;
using System.Data;

public partial class Generador : System.Web.UI.Page
{
    public const string EXCEL_2003 = ".xls";
    public const string EXCEL_2007 = ".xlsx";

    private const string FORMAT_DATETIME_LONG = "D";
    private const string SESSION_CONFIGURACION = "Configuracion";

    private static readonly string RESOURCE_INVITACION_DOCX = ConfigurationManager.AppSettings["routeInvitacionDocx"];
    private static readonly string HOUR_INITIAL = ConfigurationManager.AppSettings["hourInitial"];
    private static readonly string MINUTE_INITIAL = ConfigurationManager.AppSettings["minuteInitial"];
    private static readonly string HOUR_FINAL = ConfigurationManager.AppSettings["hourFinal"];
    private static readonly string MINUTE_FINAL = ConfigurationManager.AppSettings["minuteFinal"];
    private static readonly int INDEX_INITIAL = int.Parse(ConfigurationManager.AppSettings["indexInitial"]);
    private static readonly int INDEX_FINAL = int.Parse(ConfigurationManager.AppSettings["indexFinal"]);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string dateTimeLong = DateTime.Now.ToString(FORMAT_DATETIME_LONG);

            txtInvitacion.Text = dateTimeLong;
            txtMediacion.Text = dateTimeLong;

            HourMinuteInitial.HoraInicial = HOUR_INITIAL;
            HourMinuteInitial.MinutoFinal = MINUTE_INITIAL;
            HourMinuteInitial.IndexAMPM = INDEX_INITIAL;

            HourMinuteFinal.HoraInicial = HOUR_FINAL;
            HourMinuteFinal.MinutoFinal = MINUTE_FINAL;
            HourMinuteFinal.IndexAMPM = INDEX_FINAL;


            Configuracion configuracion = Configuracion.GetInstance();

            txtColumnCalle.Text = (configuracion.PositionCalle + 1).ToString();
            txtColumnColonia.Text = (configuracion.PositionColonia + 1).ToString();
            txtColumnCredito.Text = (configuracion.PositionCredito + 1).ToString();
            txtColumnNombre.Text = (configuracion.PositionNombre + 1).ToString();
        }
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {
        //Se inicia el proceso al finalizar la subida del archivo excel
        List<WordInfo> wordList = null;

        try
        {
            if (fileExcel.HasFile)
            {
                //Determinar si es un archivo 2003 o 2007
                Stream datos = fileExcel.FileContent;
                IExcelDataReader reader = null;

                if (Path.GetExtension(fileExcel.FileName).Equals(EXCEL_2007)) //Es archivo 2007
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(datos);
                }
                else if (Path.GetExtension(fileExcel.FileName).Equals(EXCEL_2003)) //Es 2003
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(datos);
                }

                using (reader)
                {
                    //Verificamos que sea un archivo valido
                    if (reader.IsValid)
                    {
                        //Supondremos que la primer fila es columna
                        reader.IsFirstRowAsColumnNames = true;

                        Configuracion configuracion = Configuracion.GetInstance();

                        wordList = (from read in reader.AsDataSet().Tables[0].AsEnumerable()
                                    select new WordInfo
                                    {
                                        Calle = read[configuracion.PositionCalle].ToString(),
                                        Colonia = read[configuracion.PositionColonia].ToString(),
                                        Credito = Convert.ToInt64(read[configuracion.PositionCredito]),
                                        Nombre = read[configuracion.PositionNombre].ToString()
                                    }).ToList();
                    }
                }

                WordDateInfo dateInfo = new WordDateInfo
                {
                    FechaInvitacion = DateTime.Parse(txtInvitacion.Text),
                    FechaMediacion = DateTime.Parse(txtMediacion.Text)
                };

                dateInfo.HoraInicio = new DateTime(1, 1, 1, int.Parse(HourMinuteInitial.HoraInicial), int.Parse(HourMinuteInitial.MinutoFinal), 0);
                if (HourMinuteInitial.IndexAMPM > 0)
                    dateInfo.HoraInicio = dateInfo.HoraInicio.AddHours(12);
                dateInfo.HoraFinal = new DateTime(1, 1, 1, int.Parse(HourMinuteFinal.HoraInicial), int.Parse(HourMinuteFinal.MinutoFinal), 0);
                if (HourMinuteFinal.IndexAMPM > 0)
                    dateInfo.HoraFinal = dateInfo.HoraFinal.AddHours(12);

                WordManager manager = new WordManager(wordList, Server.MapPath(RESOURCE_INVITACION_DOCX), dateInfo);
                byte[] response = manager.CreateResponse();

                Response.Clear();
                Response.ClearHeaders();
                Response.AppendHeader("content-disposition", "attachment; filename=invitaciones.zip");
                Response.ContentType = "application/zip";
                Response.OutputStream.Write(response, 0, response.Length);
            }
        }
        catch (Exception)
        {

        }
    }
    protected void btnGuardarConfiguracion_Click(object sender, EventArgs e)
    {
        Configuracion configuracion = Configuracion.GetInstance();

        configuracion.PositionCalle = Convert.ToInt32(txtColumnCalle.Text)- 1;
        configuracion.PositionColonia = int.Parse(txtColumnColonia.Text) - 1;
        configuracion.PositionCredito = int.Parse(txtColumnCredito.Text) - 1;
        configuracion.PositionNombre = int.Parse(txtColumnNombre.Text) - 1;
        configuracion.SaveConfiguration();
    }
}