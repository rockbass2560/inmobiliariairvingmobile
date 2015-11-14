using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ControlCasaBO
{
    public class Ciudad : BOBase
    {
        public static List<CiudadResult> GetCiudadesAll()
        {
            return DataAccessDAO.GetInstance().GetTableList<CiudadResult>();
        }

        public static List<CiudadResult> GetCiudades()
        {
            List<CiudadResult> ciudades;

            ciudades = Get<CiudadResult>("ciudadCasa", "ciudad", "idCiudad");

            return ciudades;
        }
    }

    [DataAccessPropierties(NameTable="ciudad")]
    public class CiudadResult : IResult
    {
        [DataAccessPropierties("idCiudad")]
        public int ID { get; set; }
        [DataAccessPropierties("nombreCiudad")]
        public string Descripcion{get;set;}
    }
    public static class CiudadConstant
    {
        public const string ID = "ID";
        public const string DESCRIPCION = "Descripcion";
    }
}
