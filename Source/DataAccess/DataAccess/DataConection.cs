using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace DataAccess
{
    class DataConection : System.Data.IDbConnection
    {
        //Objetos de conexion a base de datos
        private DbConnection connection;

        /// <summary>
        /// Constructor que tomara valores del app.config/web.config para la construccion del objeto
        /// </summary>
        public DataConection()
        {
            switch (ConfigDataAccess.ConfigSection.TypeDBManager)
            {
                case TypeDBManager.MySql:
                    connection = new MySqlConnection(ConfigDataAccess.ConfigSection.ConnectionString);
                    break;
                case TypeDBManager.SQLServer:
                    connection = new SqlConnection(ConfigDataAccess.ConfigSection.ConnectionString);
                    break;
            }
        }

        /// <summary>
        /// Constructor que tomara valores del app.config/web.config, ademas toma el tipo de administrador de base de datos como parametro
        /// </summary>
        /// <param name="dbManager">Tipo de Administrador de Base de Datos</param>
        public DataConection(TypeDBManager dbManager)
        {
            switch (dbManager)
            {
                case TypeDBManager.MySql:
                    connection = new MySqlConnection(ConfigDataAccess.ConfigSection.ConnectionString);
                    break;
                case TypeDBManager.SQLServer:
                    connection = new SqlConnection(ConfigDataAccess.ConfigSection.ConnectionString);
                    break;
            }

        }

        /// <summary>
        /// Constructor que recibira objeto con valores cargados previamente
        /// </summary>
        /// <param name="conn">Objeto de Conexion creado anteriormente</param>
        public DataConection(DbConnection conn)
        {
            connection = conn;
        }

        #region Miembros de IDbConnection

        System.Data.IDbTransaction System.Data.IDbConnection.BeginTransaction(System.Data.IsolationLevel il)
        {
            return connection.BeginTransaction(il);
        }

        public System.Data.IDbTransaction BeginTransaction()
        {
            return connection.BeginTransaction();
        }

        public int ConnectionTimeout
        {
            get { return connection.ConnectionTimeout; }
        }

        System.Data.IDbCommand System.Data.IDbConnection.CreateCommand()
        {
            return connection.CreateCommand();
        }

        public IDbCommand CreateDBCommand()
        {
            return connection.CreateCommand();
        }

        public void Open()
        {
            connection.Open();
        }

        public System.Data.ConnectionState State
        {
            get { return connection.State; }
        }

        public string Database
        {
            get { return connection.Database; }
        }

        public string ConnectionString
        {
            get { return connection.ConnectionString; }
            set { connection.ConnectionString = value; }
        }

        public void ChangeDatabase(string dbName)
        {
            connection.ChangeDatabase(dbName);
        }

        public void Close()
        {
            connection.Close();
        }

        #endregion

        #region Miembros de IDisposable

        private bool dispose = false;

        public void Dispose()
        {
            if (!dispose)
            {
                dispose = true;
                this.Dispose();
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}
