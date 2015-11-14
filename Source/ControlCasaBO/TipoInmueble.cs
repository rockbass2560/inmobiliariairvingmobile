using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace ControlCasaBO
{
    public class TipoInmueble : BOBase
    {
        public static List<TipoInmuebleResult> GetTipoInmueblesAll()
        {
            return DataAccessDAO.GetInstance().GetTableList<TipoInmuebleResult>();
        }

        public List<TipoInmuebleResult> GetTipoInmuebles()
        {
            List<TipoInmuebleResult> tipoInmuebles;

            tipoInmuebles = Get<TipoInmuebleResult>("tipoInmuebleCasa","tipoInmueble", "idTipo");

            tipoInmuebles = (from item in tipoInmuebles
                             where item.ID == 1 || item.ID == 2
                             select item).ToList();

            return tipoInmuebles;
        }
    }
    
    [DataAccessPropierties(NameTable="tipoinmueble")]
    public class TipoInmuebleResult : IResult
    {
        [DataAccessPropierties("idTipo")]
        public int ID { get; set; }
        [DataAccessPropierties("nombreTipo")]
        public string Descripcion { get; set; }
    }
    public static class TipoInmuebleConstant
    {
        public const string ID = "ID";
        public const string DESCRIPCION = "Descripcion";
    }
}
