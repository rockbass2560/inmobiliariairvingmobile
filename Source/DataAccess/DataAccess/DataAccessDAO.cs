using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DataAccess
{
    /// <summary>
    /// Esta clase representa el acceso a datos, se necesita un objeto DataAcessCommand
    /// el cual trae configurado todas las configuraciones, parametros y conexion para ejecutar
    /// la consulta SQL, DataAcessDao se ocupara tambien de transformar los resultado en objetos Filter
    /// </summary>
    public class DataAccessDAO
    {
        /// <summary>
        /// Constructor privado, para evitar instancias de la clase, como su objetivo es para web, normalmente solo
        /// se puede establecer 1 conexion por cliente lo que resulta inecesario las instancias
        /// </summary>
        private DataAccessDAO()
        {
            //Se aplica patron singleton, con un solo DAO puede realizar todas sus operaciones
        }

        /// <summary>
        /// Instancia para aplicar patron singlenton
        /// </summary>
        private static DataAccessDAO dataAccessDao = new DataAccessDAO();

        /// <summary>
        /// Metodo que devuelve la unica instancia del DAO
        /// </summary>
        /// <returns>Objeto DataAcessDAO</returns>
        public static DataAccessDAO GetInstance()
        {
            //Se decidio por patorn singleton
            return dataAccessDao;
            //Se crearan instancias para no congelar la aplicacion con multiples instancias
            //return new DataAccessDAO();
        }

        public Dictionary<T, K> GetTableList<T,K>(string tableName, string key, string value)
        {
            Dictionary<T, K> diccionario=new Dictionary<T,K>();

            DataAccessCommand comm = new DataAccessCommand(DataAccessHelper.CreateSelectTable(tableName), CommandType.Text);

            IDataReader reader = comm.Command.ExecuteReader();

            while (reader.Read())
            {
                diccionario.Add((T)reader[key], (K)reader[value]);
            }

            return diccionario;
        }

        /// <summary>
        /// Esta consulta buscara el parametro de NameTable en la clase Result recibida como type, ejecutara una consulta
        /// SELECT * FROM NameTable, el cual transformara las propiedades del objeto Result con las recibidas en la consulta
        /// </summary>
        /// <typeparam name="T">Objeto Result que contendra las propiedad NameTable y Property</typeparam>
        /// <returns>Result con las propiedaes Mapeadas</returns>
        public List<T> GetTableList<T>()
        {
            List<T> listaRetorno;
            DataAccessCommand comm = new DataAccessCommand(DataAccessHelper.CreateSelectTable<T>(), CommandType.Text);

            listaRetorno = GetList<T>(comm);

            return listaRetorno;

        }

        /// <summary>
        /// Ejecuta una consulta SQL y regresa el numero de tabla afectada, su uso se limita para instrucciones
        /// DELETE, UPDATE E INSERT
        /// </summary>
        /// <param name="comm">Objeto de command que contiene el Query o Store</param>
        /// <returns>Entero con la cantidad de filas afectas, -1 cuando hay un error</returns>
        public int ExecuteAction(DataAccessCommand comm)
        {
            return comm.Command.ExecuteNonQuery();
        }

        /// <summary>
        /// Metodo que devuelve solo el primer objeto encontrado en una lista
        /// Normalmente se debera usar en consulta que regresen una fila (Mas sera exceso de memoria y datos)
        /// </summary>
        /// <typeparam name="T">Objeto Result que se espera de regreso</typeparam>
        /// <param name="comm">Commando que tendra parametros SQL, nombre de consulta, tipo de conexion, etc.</param>
        /// <returns>Objeto Result esperado</returns>
        /// <seealso cref="GetList<T>"/>
        public T GetOneRow<T>(DataAccessCommand comm)
        {
            return GetList<T>(comm).First();
        }

        /// <summary>
        /// Metodo que devolvera el resultado en un objeto DataSet en lugar de Mapearlo a un objeto Result
        /// </summary>
        /// <param name="comm"></param>
        /// <returns>DataSet con el resultado de la consulta</returns>
        public DataSet GetDataSet(DataAccessCommand comm)
        {
            DataSet dataSet = new DataSet();
            DataAdapter adapter = comm.CreateDataAdapter();
            adapter.Fill(dataSet);

            return dataSet;
        }

        /// <summary>
        /// Ejecutara una consulta SQL y solo obtendra el primer valor, de la primera fila
        /// </summary>
        /// <param name="comm"></param>
        /// <returns></returns>
        public object GetFirstResult(DataAccessCommand comm)
        {
            return comm.Command.ExecuteScalar();
        }

        public Dictionary<K,V> GetListDictionary<K,V>(DataAccessCommand comm, string key, string value)
        {
            Dictionary<K, V> diccionario=new Dictionary<K,V>();

            IDataReader reader = comm.Command.ExecuteReader();

            while (reader.Read())
            {
                //Se esperan 2 campos en la consultar...
                diccionario.Add((K)reader[key], (V)reader[value]);

            }

            return diccionario;
        }

        /// <summary>
        /// Metodo que devolvera una lista de datos de acuerdo a un objeto de dominio (Clase que Mapea Campos Esperados)
        /// cabe observar que se deberan cumplir una serie de criterios en el objeto, debera tener el constructor sin parametros disponible,
        /// ademas debera contener en sus propiedades el atributo NameColumn de la clase DataAccessPropierties
        /// </summary>
        /// <typeparam name="T">Objeto de Dominio</typeparam>
        /// <param name="comm">Comando a Ejecutar en Base de Datos</param>
        /// <returns>Lista con los Objetos de Dominio</returns>
        public List<T> GetList<T>(DataAccessCommand comm)
        {
            List<T> listaRetorno = new List<T>();
            IDbCommand command = comm.Command;

            try
            {
                    IDataReader reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            //Se crea el objeto con un casteo
                            T objectDomain = (T)DataAccessHelper.CreateDomainObject<T>(reader);

                            //Se agrega a la lista
                            listaRetorno.Add(objectDomain);
                        }
                    }
            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            
            return listaRetorno;
        }
    }
}
