using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;
using System.IO;

namespace DataAccess
{
    static class DataAccessHelper
    {
        static DataAccessHelper()
        {
            CreateDataMap();
        }

        #region Manejo de Querys
        internal static string CreateSelectTable(string nameTable)
        {
            string query = String.Format("SELECT * FROM {0}", nameTable);

            return query;
        }
        internal static string CreateSelectTable<T>()
        {
            string nameTable = GetNameTable<T>();

            string query = String.Format("SELECT * FROM {0}", nameTable);

            return query;
        }
        #endregion

        #region Mapeo de datos

        internal static string GetNameTable<T>()
        {
            string nameTable = string.Empty;

            DataAccessPropierties prop = Attribute.GetCustomAttribute(typeof(T), typeof(DataAccessPropierties)) as DataAccessPropierties;

            nameTable = prop.NameTable;

            return nameTable;
        }

        /// <summary>
        /// Este metodo crea objetos de dominio a partir de un reader, cabe observar que se deberan cumplir
        /// una serie de criterios en el objeto, debera tener el constructor sin parametros disponible,
        /// ademas debera contener en sus propiedades el atributo de DataAccessPropierties
        /// </summary>
        /// <typeparam name="T">Tipo de Objeto de Dominio</typeparam>
        /// <param name="reader">Reader de donde se obtendran los datos</param>
        /// <returns>El objeto de dominio en clase</returns>
        public static object CreateDomainObject<T>(IDataReader reader)
        {
            //Se crea el objeto dinamicamente, este debera tener el constructor por default
            T domainObject = (T)typeof(T).GetConstructor(new Type[] { }).Invoke(null);

            for (int index = 0; index < reader.FieldCount; index++)
            {
                string nameColum = reader.GetName(index);
                object value=reader.GetValue(index);

                SetValueDomainObject(domainObject, nameColum, value);
            }

            return domainObject;
        }

        /// <summary>
        /// Metodo que setea la propiedad que corresponda al nombre de la tabla, esta se verifica por medio del atributo
        /// NameColumn de la clase DataAccessPropierties
        /// </summary>
        /// <exception cref="System.Exception">Excepcion que se genera si la clase no contiene el atributo</exception>
        /// <param name="obj">Objeto al que se le va a setear el valor</param>
        /// <param name="nameAttribute">Nombre del atributo a buscar (Campo de la tabla)</param>
        /// <param name="value">Valor a setear</param>
        static void SetValueDomainObject(object obj, string nameAttribute, object value)
        {

            PropertyInfo[] properties = obj.GetType().GetProperties();
            string propertyName=string.Empty;

            try
            {
                properties.DefaultIfEmpty(null);

                if (properties.Count() < 1)
                {
                    throw new Exception("La clase no contiene propiedades");
                }

                PropertyInfo propiedad = properties.FirstOrDefault(
                    prop =>
                    {
                        propertyName = prop.Name;
                        if (Attribute.IsDefined(prop,typeof(DataAccessPropierties)))
                        {
                            DataAccessPropierties attr=Attribute.GetCustomAttribute(prop,typeof(DataAccessPropierties)) as DataAccessPropierties;
                            if (attr.IgnorePropierty)
                                return false;
                            if (attr.NameColumn.Equals(nameAttribute))
                                return true;
                        }
                        return false;
                    }
                    );

                if (propiedad == null)
                {
                    return;
                }

                //Se valida que no sea un valor nulo en base de datos... de serlo se deja en null
                if (!Convert.IsDBNull(value))
                    propiedad.SetValue(obj, value, null);
                else
                    propiedad.SetValue(obj, null, null);
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("No se a encontrado la propiedad {0} en el Result", propertyName), ex, propertyName);
            }
        }

        #endregion
        #region Mapeo de Parametros

        /// <summary>
        /// Metodo que determina el DBType de un Type en .NET
        /// </summary>
        /// <param name="parameterType">Se recibe el valor y determinara automaticamente su tipo</param>
        /// <returns>Un DBType correspondiente</returns>
        public static DbType GetDBType(Type parameterType)
        {
            return typeMap[parameterType];
        }
        
        //Creacion de Mapeo de Tipos de Datos .Net en DBType
        private static Dictionary<Type, DbType> typeMap=new Dictionary<Type,DbType>();

        private static void CreateDataMap(){
            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;
            typeMap[typeof(int?)] = DbType.Int32;
            typeMap[typeof(uint?)] = DbType.UInt32;
            typeMap[typeof(long?)] = DbType.Int64;
            typeMap[typeof(ulong?)] = DbType.UInt64;
            typeMap[typeof(float?)] = DbType.Single;
            typeMap[typeof(double?)] = DbType.Double;
            typeMap[typeof(decimal?)] = DbType.Decimal;
            typeMap[typeof(bool?)] = DbType.Boolean;
            typeMap[typeof(char?)] = DbType.StringFixedLength;
            typeMap[typeof(Guid?)] = DbType.Guid;
            typeMap[typeof(DateTime?)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
            //typeMap[typeof(System.Data.Linq.Binary)] = DbType.Binary;
        }
        #endregion
    }
}
