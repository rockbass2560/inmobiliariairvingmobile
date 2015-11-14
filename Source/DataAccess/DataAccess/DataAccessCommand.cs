using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace DataAccess
{
    public class DataAccessCommand : IDisposable
    {
        private IDbCommand command;
        private IDbTransaction transaction;
        private object filter;

        internal IDbCommand Command
        {
            get { return command; }
        }
        /// <summary>
        /// Representa a un objeto filter, el cual sera agregado como parametros SQL para un store
        /// </summary>
        public object Filter
        {
            get { return filter; }
            set
            { 
                filter = value;
                SetFilter();
            }
        }

        /// <summary>
        /// Abre una transaccion (BeginTransaction) en caso de no tener, se utiliza 1 vez por instancia
        /// </summary>
        public void AbrirTransaccion()
        {
            if (transaction == null)
            {
                transaction = command.Connection.BeginTransaction();
                command.Transaction = transaction;
            }
        }

        /// <summary>
        /// Realiza un commit con la transaccion, realizando todos los cambios permanentemente
        /// </summary>
        public void CerrarTransaccion()
        {
            if (transaction != null)
            {
                transaction.Commit();
            }
        }

        /// <summary>
        /// Realiza un rollback sobre la transaccion, cancelando todo los cambios realizados
        /// </summary>
        public void CancelarTransaccion()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
        }

        /// <summary>
        /// Permite cambiar el commando SQL a usar sin necesidad de crear otra instancia
        /// </summary>
        /// <param name="textCommand">Comando SQL</param>
        /// <param name="type">Tipo de Comando (Query, Store, Table)</param>
        /// <param name="filter">Filter a utilizar</param>
        public void SetCommand(string textCommand,CommandType type,object filter)
        {
            SetCommand(textCommand,type);

            Filter = filter;
        }

        /// <summary>
        /// Permite cambiar el commando SQL a usar sin necesidad de crear otra instancia
        /// </summary>
        /// <param name="textCommand">Comando SQL</param>
        /// <param name="type">Tipo de Comando (Query, Store, Table)</param>
        public void SetCommand(string textCommand, CommandType type)
        {
            SetCommand(textCommand);

            command.CommandType = type;
        }

        /// <summary>
        /// Permite cambiar el commando SQL a usar sin necesidad de crear otra instancia
        /// </summary>
        /// <param name="textCommand">Comando SQL (Store Procedure predeterminadamente)</param>
        public void SetCommand(string textCommand) 
        {
            command = command.Connection.CreateCommand();
            command.Transaction = transaction;
            command.Parameters.Clear();
            command.CommandText = textCommand;
            command.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// Instancia para crear el objeto sin establecer un query primero
        /// </summary>
        public DataAccessCommand()
        {
            DataConection connection = new DataConection();
            command = connection.CreateDBCommand();
            //Se abre una sola conexion
            command.Connection.Open();
        }

        /// <summary>
        /// Constructor del Objeto Commando, predeterminadamente sera un store procedure sin parametros de entrada ni salida
        /// </summary>
        /// <param name="textCommand">Comando SQL</param>
        public DataAccessCommand(string textCommand) : this()
        {
            command.CommandText = textCommand;
            command.CommandType = CommandType.StoredProcedure;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textCommand"></param>
        /// <param name="type"></param>
        public DataAccessCommand(string textCommand, CommandType type) : this(textCommand)
        {
            command.CommandType = type;
        }

        /// <summary>
        /// Constructor del Objeto Commando, predeterminadamente sera un store procedure sin parametros de entrada ni salida
        /// </summary>
        /// <param name="textCommand">Comando SQL a usar</param>
        /// <param name="filter">Filter para el store procedure</param>
        public DataAccessCommand(string textCommand, object filter) : this(textCommand,CommandType.StoredProcedure)
        {
            Filter = filter;
        }

        /// <summary>
        /// Constructor del Objeto Commando, predeterminadamente sera un store procedure sin parametros de entrada ni salida
        /// </summary>
        /// <param name="textCommand">Comando SQL</param>
        /// <param name="type"></param>
        /// <param name="filter"></param>
        public DataAccessCommand(string textCommand, CommandType type, object filter):this(textCommand,type)
        {
            Filter = filter;
        }

        /// <summary>
        /// Metodo que crea un DataAdapter Generico
        /// </summary>
        /// <param name="command">Objeto DBCommand necesario para la creacion del data adapter</param>
        /// <returns>Objeto DataAdapter</returns>
        internal DataAdapter CreateDataAdapter()
        {
            DataAdapter adapter=null;
            switch (ConfigDataAccess.ConfigSection.TypeDBManager)
            {
                case TypeDBManager.MySql:
                    adapter = new MySqlDataAdapter((MySqlCommand)command);
                    break;
                case TypeDBManager.SQLServer:
                    adapter = new SqlDataAdapter((SqlCommand)command);
                    break;
            }
            return adapter;
        }

        public void SetParamater(string nameParameter, Type typeParameter, object value)
        {
            IDataParameter parameter;

            //Se evalua si el parametro existe
            if (command.Parameters.Contains(nameParameter))
                parameter = command.Parameters[nameParameter] as IDataParameter;
            else
                parameter = command.CreateParameter();

            parameter.DbType = DataAccessHelper.GetDBType(typeParameter);
            parameter.ParameterName = nameParameter;
            parameter.Value = value;

            command.Parameters.Add(parameter);            
        }

        private void SetFilter()
        {
            foreach (PropertyInfo info in Filter.GetType().GetProperties())
            {
                if (info.GetCustomAttributes(false).Count() > 0)
                {
                    DataAccessParameter parametro = info.GetCustomAttributes(typeof(DataAccessParameter), false)[0] as DataAccessParameter;

                    SetParamater(parametro.NameParameter, info.PropertyType, info.GetValue(Filter, null));
                }
            }
        }

        #region Miembros de IDisposable

        private bool dispose = false;

        private void Dispose(bool dispose)
        {
            if (dispose)
            {
                if (command.Connection.State == ConnectionState.Open)
                    command.Connection.Close();
                GC.SuppressFinalize(this);
            }
        }

        virtual public void Dispose()
        {
            if (!dispose)
            {
                dispose = true;
                Dispose(dispose);
            }
        }

        #endregion
    }
}
