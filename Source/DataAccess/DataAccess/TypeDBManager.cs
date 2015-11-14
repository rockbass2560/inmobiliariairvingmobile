using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    /// <summary>
    /// Enumerador que permite seleccionar una base de datos especifica, normalmente estara
    /// configurada en el archivo config (app.config o web.config)
    /// </summary>
    public enum TypeDBManager
    {
        /// <summary>
        /// Manejador de Base de Datos SQL Server (Driver Nativo .Net)
        /// </summary>
        SQLServer,
        /// <summary>
        /// Manejador de Base de Datos MySQL, Driver .Net del proveedor
        /// </summary>
        MySql
    }
}
