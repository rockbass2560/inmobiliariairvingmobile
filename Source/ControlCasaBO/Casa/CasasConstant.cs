using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlCasaBO
{
    static class CasasConstantStoreProcedure
    {
        public const string GETCASAS = "ObtenerCasas";
        public const string GETCASASENVENTA = "ObtenerCasasEnVenta";
        public const string OBTENERCASASRESULTADO = "BusquedaCasas";
        public const string OBTENERCASABYID = "ObtenerCasaByID";
    }
    static class CasasParametersIn
    {
        public const string ENVENTA = "enVenta";

        //Parametros para store procedure de busquedas
        public const string TIPOTRANSACCION = "tipoTransaccion";
        public const string TIPOINMUEBLE = "tipoInmueble";
        public const string CIUDAD = "ciudad";
        public const string COLONIA = "colonia";
        public const string PRECIOMENOR = "precioMenor";
        public const string PRECIOMAYOR = "precioMayor";
    }
    static class CasasField
    {
        public const string ID = "idCasa";
        public const string ENVENTA = "enVentaCasa";
    }
}
