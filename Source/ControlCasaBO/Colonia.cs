using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace ControlCasaBO
{
    public class Colonia : BOBase
    {
        public static List<ColoniaResult> GetColoniasAll()
        {
            List<ColoniaResult> colonias;

            DataAccessDAO dao = DataAccessDAO.GetInstance();
            colonias = dao.GetTableList<ColoniaResult>();

            //Ordenar por ID
            colonias = colonias.OrderBy(colonia => colonia.Descripcion).ToList();

            return colonias;
        }
        public static List<ColoniaResult> GetColonias()
        {
            List<ColoniaResult> colonias;

            colonias = Get<ColoniaResult>("coloniaCasa", "colonia", "idColonia");

            return colonias;
        }
    }

    [DataAccessPropierties(NameTable="colonia")]
    public class ColoniaResult : IResult
    {
        [DataAccessPropierties("idColonia")]
        public int ID { get; set; }
        [DataAccessPropierties("nombreColonia")]
        public string Descripcion { get; set; }
    }
    public static class ColoniaStoreProcedure
    {
        public const string COLONIASCONCASA = "ObtenerColoniasConCasa";
    }
    public static class ColoniaConstant
    {
        public const string ID = "ID";
        public const string DESCRIPCION = "Descripcion";
    }
}
