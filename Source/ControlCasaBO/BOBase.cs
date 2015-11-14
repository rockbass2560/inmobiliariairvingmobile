using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ControlCasaBO
{
    public abstract class BOBase
    {
        protected DataAccessCommand command=new DataAccessCommand();

        public BOBase()
        {
        }

        public BOBase(bool createTransaction)
        {
            if (createTransaction)
                OpenTransaction();
        }

        public void OpenTransaction()
        {
            command.AbrirTransaccion();
        }

        public void RollBack()
        {
            command.CancelarTransaccion();
        }

        public void Commit()
        {
            command.CerrarTransaccion();
        }

        private const string CADENASQL = "SELECT DISTINCT {0}.* FROM {0} INNER JOIN {1} ON {2}={3} WHERE enVentaCasa=1";

        //Metodo pendiente
        /*public static Dictionary<K, V> ObtenerCatalogo<K, V>(params object parameters)
        {
            Dictionary<K, V> diccionario = new Dictionary<K, V>();

            return diccionario;
        }*/

        protected static List<T> Get<T>(string fromField,string joinTable, string joinField)
        {
            DataAccessDAO dao = DataAccessDAO.GetInstance();

            BOBasFilter filter = new BOBasFilter();
            filter.FromTable = "casa";
            filter.FromField = fromField;
            filter.JoinTable = joinTable;
            filter.JoinField = joinField;

            DataAccessCommand command = new DataAccessCommand("ObtenerCatalogo", filter);

            //DataAccessCommand command = new DataAccessCommand(FormatQuery(fromTable, innerTable, fromField, innerField), CommandType.Text);

            List<T> lista = dao.GetList<T>(command);

            var nuevaLista = (from q in lista.Cast<IResult>()
                                orderby q.Descripcion
                                select q);

            lista = nuevaLista.Cast<T>().ToList<T>();

            return lista;
        }
        private static string FormatQuery(string fromTable, string innerTable, string fromField, string innerField)
        {
            return String.Format(CADENASQL, fromTable, innerTable, fromField, innerField);
        }
    }
    internal class BOBasFilter
    {
        [DataAccessParameter("tableFrom")]
        public string FromTable { get; set; }
        [DataAccessParameter("fieldFrom")]
        public string FromField { get; set; }
        [DataAccessParameter("tableJoin")]
        public string JoinTable { get; set; }
        [DataAccessParameter("fieldJoin")]
        public string JoinField { get; set; }
    }
}
