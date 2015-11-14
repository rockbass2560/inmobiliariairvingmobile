using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace ControlCasaBO
{
    public class Forma : BOBase
    {
        public static List<FormaResult> GetFormaAll()
        {
            return DataAccessDAO.GetInstance().GetTableList<FormaResult>();
        }
    }
    [DataAccessPropierties(NameTable="forma")]
    public class FormaResult : IResult
    {
        #region Miembros de IResult

        [DataAccessPropierties("idForma")]
        public int ID { get; set; }

        [DataAccessPropierties("nombreForma")]
        public string Descripcion { get; set; }

        #endregion
    }
}
