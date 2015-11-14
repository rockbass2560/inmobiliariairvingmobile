using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace ControlCasaBO
{
    public class TipoVenta : BOBase
    {
        public static List<TipoVentaResult> GetTipoVentaAll()
        {
            return DataAccessDAO.GetInstance().GetTableList<TipoVentaResult>();
        }

        public static List<TipoVentaResult> GetTipoVenta()
        {
            List<TipoVentaResult> tipoVenta;

            tipoVenta = Get<TipoVentaResult>("tipoTransaccionCasa", "tipoTransaccion", "idTipoTransaccion");

            return tipoVenta;
        }

        public static List<TipoVentaResult> GetTipoVenta(params int[] id)
        {
            List<TipoVentaResult> tipoVenta;

            tipoVenta = Get<TipoVentaResult>("tipoTransaccionCasa","tipoTransaccion", "idTipoTransaccion");

            tipoVenta = tipoVenta.Where(item => id.Contains(item.ID)).ToList();

            return tipoVenta;
        }
    }
    
    [DataAccessPropierties(NameTable="tipotransaccion")]
    public class TipoVentaResult : IResult
    {
        [DataAccessPropierties("idTipoTransaccion")]
        public int ID {get;set;}
        [DataAccessPropierties("nombreTipoTransaccion")]
        public string Descripcion {get;set;}
    }
    public static class TipoVentaConstant
    {
        public const string ID = "ID";
        public const string Descripcion = "Descripcion";
    }
}
