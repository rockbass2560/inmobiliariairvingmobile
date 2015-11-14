using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using System.Configuration;

namespace ControlCasaBO
{
    public class Casas : BOBase
    {
        public Casas()
        {
        }
        public Casas(bool createTransaction)
            : base(createTransaction)
        {
            
        }

        public int GetID()
        {
            command.SetCommand("CreateID");

            return Convert.ToInt32(DataAccessDAO.GetInstance().GetFirstResult(command));            
        }

        public void UpdateCasa(CasaFilter filter)
        {
            command.SetCommand("UpdateCasa", CommandType.StoredProcedure, filter);

            DataAccessDAO dao = DataAccessDAO.GetInstance();

            dao.ExecuteAction(command);
        }

        public static int CambiarEstadoEnVenta(int id, bool enVenta)
        {
            byte enVentaByte = Convert.ToByte(enVenta);

            DataAccessCommand command = new DataAccessCommand("UPDATE casa SET enVentaCasa=" + enVentaByte + " WHERE idCasa=" + id, CommandType.Text);

            DataAccessDAO dao = DataAccessDAO.GetInstance();

            int resultado = dao.ExecuteAction(command);

            return resultado;
        }

        public static List<CasasResultPanel> ObtenerCasasPanel(CasasPanelFilter filterBusqueda)
        {
            DataAccessDAO dao = DataAccessDAO.GetInstance();

            DataAccessCommand command = new DataAccessCommand("BusquedaCasasPanel", filterBusqueda);

            List<CasasResultPanel> casas = dao.GetList<CasasResultPanel>(command);

            string editHRef=ConfigurationManager.AppSettings["editHRef"];
            string deleteHRef=ConfigurationManager.AppSettings["deleteHRef"];

            casas.ForEach(casa =>
                {
                    casa.EditHRef = String.Format(editHRef, casa.ID);
                    //casa.DeleteHRef = String.Format(deleteHRef, casa.ID);
                    casa.DeleteHRef = "javascript:eliminarCasa(" + casa.ID + ","+ casa.EnVenta.ToString().ToLower() +")";
                    casa.Estado = (casa.EnVenta) ? "Deshabilitar" : "Habilitar";
                }
                );

            return casas;
        }
        /// <summary>
        /// Metodo para Obtener Casas para la pagina de busqueda, aplica filtros de tipo de inmueble o colonia
        /// </summary>
        /// <param name="filterBusqueda"></param>
        /// <param name="inicio"></param>
        /// <param name="final"></param>
        /// <returns></returns>
        public static List<CasasResult> ObtenerCasasResultado(CasasFilterBusqueda filterBusqueda)
        {
            DataAccessDAO dao = DataAccessDAO.GetInstance();

            DataAccessCommand command = new DataAccessCommand(CasasConstantStoreProcedure.OBTENERCASASRESULTADO, filterBusqueda);

            List<CasasResult> casas = dao.GetList<CasasResult>(command);

            CasaHelper.FormatProperty<CasasResult>(casas);

            return casas;
        }
        /// <summary>
        /// Consulta que devuelve un result ubicado por ID, se espera que sea solo un registro
        /// Se usa en la pagina de detalles de casa
        /// </summary>
        /// <param name="id">ID de la casa en la Base de Datos</param>
        /// <returns>Result de la Casa</returns>
        public static CasasResultById ObtenerCasasById(int id)
        {
            DataAccessDAO dao = DataAccessDAO.GetInstance();

            DataAccessCommand command = new DataAccessCommand(CasasConstantStoreProcedure.OBTENERCASABYID);
            command.SetParamater("ID", id.GetType(), id);

            CasasResultById casa = dao.GetOneRow<CasasResultById>(command);

            CasaHelper.FormatProperty<CasasResultById>(casa);

            return casa;
        }

        public static CasaCatalogoResult ObtenerCasa(int id)
        {
            DataAccessCommand command = new DataAccessCommand("ObtenerCasa");
            command.SetParamater("ID", typeof(int), id);

            return DataAccessDAO.GetInstance().GetOneRow<CasaCatalogoResult>(command);
        }
    }

    public class CasasResultPanel : CasasResult
    {
        [DataAccessPropierties(IgnorePropierty = true)]
        public string EditHRef { get; set; }
        [DataAccessPropierties(IgnorePropierty = true)]
        public string DeleteHRef { get; set; }
        [DataAccessPropierties(IgnorePropierty = true)]
        public string Estado { get; set; }
        [DataAccessPropierties("EnVenta")]
        public bool EnVenta { get; set; }
    }

    public class CasaCatalogoResult
    {
        [DataAccessPropierties("ID")]
        public int ID { get; set; }
        [DataAccessPropierties("Calle")]
        public string Calle { get; set; }
        [DataAccessPropierties("Numero")]
        public string Numero { get; set; }
        [DataAccessPropierties("Precio")]
        public Single Precio { get; set; }
        [DataAccessPropierties("Colonia")]
        public int Colonia { get; set; }
        [DataAccessPropierties("Ciudad")]
        public int Ciudad { get; set; }
        [DataAccessPropierties("TipoInmueble")]
        public int TipoInmueble { get; set; }
        [DataAccessPropierties("TipoTransaccion")]
        public int TipoTransaccion { get; set; }
        [DataAccessPropierties("Forma")]
        public int Forma { get; set; }
        [DataAccessPropierties("CodigoPostal")]
        public string CodigoPostal { get; set; }
        [DataAccessPropierties("Propietario")]
        public string Propietario { get; set; }
        [DataAccessPropierties("Niveles")]
        public int Niveles { get; set; }
        [DataAccessPropierties("Recamara")]
        public int Recamaras { get; set; }
        [DataAccessPropierties("Cochera")]
        public int Cochera { get; set; }
        [DataAccessPropierties("Bano")]
        public float Baños { get; set; }
        [DataAccessPropierties("Terreno")]
        public float Terreno { get; set; }
        [DataAccessPropierties("Construccion")]
        public float Construccion { get; set; }
        [DataAccessPropierties("Descripcion")]
        public string Descripcion { get; set; }
        [DataAccessPropierties("Frente")]
        public float Frente { get; set; }
        [DataAccessPropierties("Fondo")]
        public float Fondo { get; set; }
        [DataAccessPropierties("Esquina")]
        public bool Esquina { get; set; }
        [DataAccessPropierties("Jardin")]
        public bool Jardin { get; set; }
        [DataAccessPropierties("Estudio")]
        public bool Estudio { get; set; }
        [DataAccessPropierties("Alberca")]
        public bool Alberca { get; set; }
        [DataAccessPropierties("Edad")]
        public int Edad { get; set; }
        [DataAccessPropierties("Telefono")]
        public string Telefono { get; set; }
        [DataAccessPropierties("EnVenta")]
        public bool EnVenta { get; set; }
        [DataAccessPropierties("Fotografia")]
        public string Fotografia { get; set; }
    }

    public class CasaFilter
    {
        [DataAccessParameter("ID")]
        public int ID { get; set; }
        [DataAccessParameter("Calle")]
        public string Calle { get; set; }
        [DataAccessParameter("Numero")]
        public string Numero { get; set; }
        [DataAccessParameter("Precio")]
        public Single Precio { get; set; }
        [DataAccessParameter("Colonia")]
        public int Colonia { get; set; }
        [DataAccessParameter("Ciudad")]
        public int Ciudad { get; set; }
        [DataAccessParameter("TipoInmueble")]
        public int TipoInmueble { get; set; }
        [DataAccessParameter("TipoTransaccion")]
        public int TipoTransaccion { get; set; }
        [DataAccessParameter("Forma")]
        public int Forma { get; set; }
        [DataAccessParameter("CodigoPostal")]
        public string CodigoPostal { get; set; }
        [DataAccessParameter("Propietario")]
        public string Propietario { get; set; }
        [DataAccessParameter("Niveles")]
        public int Niveles { get; set; }
        [DataAccessParameter("Recamara")]
        public int Recamaras { get; set; }
        [DataAccessParameter("Cochera")]
        public int Cochera { get; set; }
        [DataAccessParameter("Bano")]
        public float Baños { get; set; }
        [DataAccessParameter("Terreno")]
        public float Terreno { get; set; }
        [DataAccessParameter("Construccion")]
        public float Construccion { get; set; }
        [DataAccessParameter("Descripcion")]
        public string Descripcion { get; set; }
        [DataAccessParameter("Frente")]
        public float Frente { get; set; }
        [DataAccessParameter("Fondo")]
        public float Fondo { get; set; }
        [DataAccessParameter("Esquina")]
        public bool Esquina { get; set; }
        [DataAccessParameter("Jardin")]
        public bool Jardin { get; set; }
        [DataAccessParameter("Estudio")]
        public bool Estudio { get; set; }
        [DataAccessParameter("Alberca")]
        public bool Alberca { get; set; }
        [DataAccessParameter("Edad")]
        public int Edad { get; set; }
        [DataAccessParameter("Telefono")]
        public string Telefono { get; set; }
        [DataAccessParameter("EnVenta")]
        public bool EnVenta { get; set; }
        [DataAccessParameter("Fotografia")]
        public string Fotografia {get;set;}
    }

    [DataAccessPropierties(NameTable="casa")]
    public class CasasResultById
    {
        [DataAccessPropierties("ID")]
        public int ID { get; set; }
        [DataAccessPropierties("Calle")]
        public string Calle { get; set; }
        [DataAccessPropierties("Numero")]
        public string Numero { get; set; }
        [DataAccessPropierties("Precio")]
        public Single Precio { get; set; }
        [DataAccessPropierties("Colonia")]
        public string Colonia { get; set; }
        [DataAccessPropierties("Ciudad")]
        public string Ciudad { get; set; }
        [DataAccessPropierties("TipoInmueble")]
        public string TipoInmueble { get; set; }
        [DataAccessPropierties("TipoTransaccion")]
        public string TipoTransaccion { get; set; }
        [DataAccessPropierties("CodigoPostal")]
        public string CodigoPostal { get; set; }
        [DataAccessPropierties("Niveles")]
        public int Niveles { get; set; }
        [DataAccessPropierties("Recamaras")]
        public int Recamaras { get; set; }
        [DataAccessPropierties("Cochera")]
        public int Cochera { get; set; }
        [DataAccessPropierties("Banos")]
        public float Baños { get; set; }
        [DataAccessPropierties("Terreno")]
        public float Terreno { get; set; }
        [DataAccessPropierties("Construccion")]
        public float Construccion { get; set; }
        [DataAccessPropierties("Descripcion")]
        public string Descripcion { get; set; }
        [DataAccessPropierties("Frente")]
        public float Frente { get; set; }
        [DataAccessPropierties("Fondo")]
        public float Fondo { get; set; }
        [DataAccessPropierties("Esquina")]
        public bool Esquina { get; set; }
        [DataAccessPropierties("Jardin")]
        public bool Jardin { get; set; }
        [DataAccessPropierties("Estudio")]
        public bool Estudio { get; set; }
        [DataAccessPropierties("Alberca")]
        public bool Alberca { get; set; }
        [DataAccessPropierties("Telefono")]
        public string Telefono { get; set; }

        [DataAccessPropierties("Fotografia")]
        public string Fotografia
        {
            get;set;
        }
    }

    //Mapeo de Objeto de Dominio, son resultados en base de datos
    //Este corresponde a una tabla de casa
    public class CasasResult
    {
        [DataAccessPropierties("ID")]
        public int ID {get;set;}
        [DataAccessPropierties("Calle")]
        public string Calle { get; set; }
        [DataAccessPropierties("Precio")]
        public Single Precio { get; set; }
        [DataAccessPropierties("Colonia")]
        public string Colonia { get; set; }
        [DataAccessPropierties("Ciudad")]
        public string Ciudad { get; set; }
        [DataAccessPropierties("TipoInmueble")]
        public string TipoInmueble { get; set; }
        [DataAccessPropierties("TipoTransaccion")]
        public string TipoTransaccion { get; set; }
        [DataAccessPropierties("Recamaras")]
        public int Recamaras { get; set; }
        [DataAccessPropierties("Banos")]
        public float Baños { get; set; }
        [DataAccessPropierties("Terreno")]
        public float Terreno { get; set; }
        [DataAccessPropierties("Construccion")]
        public float Construccion { get; set; }
        [DataAccessPropierties("Descripcion")]
        public string Descripcion { get; set; }
        [DataAccessPropierties("Fotografia")]
        public string Fotografia { get; set; }
    }

    public class CasasPanelFilter
    {
        [DataAccessParameter("index")]
        public int? Index { get; set; }
        [DataAccessParameter("count")]
        public int? Count { get; set; }
    }

    //Mapeo para parametros de entrada u objetos de filtrado
    public class CasasFilterBusqueda
    {
        [DataAccessParameter(CasasParametersIn.TIPOTRANSACCION)]
        public string TipoVenta { get; set; }
        [DataAccessParameter(CasasParametersIn.TIPOINMUEBLE)]
        public string TipoInmueble {get;set;}
        [DataAccessParameter(CasasParametersIn.CIUDAD)]
        public string Ciudad { get; set; }
        [DataAccessParameter(CasasParametersIn.COLONIA)]
        public string Colonia { get; set; }
        [DataAccessParameter(CasasParametersIn.PRECIOMENOR)]
        public decimal? PrecioMenor { get; set; }
        [DataAccessParameter(CasasParametersIn.PRECIOMAYOR)]
        public decimal? PrecioMayor { get; set; }
        [DataAccessParameter("index")]
        public int? Index { get; set; }
        [DataAccessParameter("count")]
        public int? Count { get; set; }
    }
}
