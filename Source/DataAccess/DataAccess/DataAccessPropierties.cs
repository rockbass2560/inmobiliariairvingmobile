using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    //Clase de Atributos
    public class DataAccessPropierties : System.Attribute
    {
        public DataAccessPropierties()
        {
        }
        public DataAccessPropierties(string nameColumn)
        {
            NameColumn = nameColumn;
        }

        public string NameColumn { get; set; }

        public string NameTable { get; set; }

        public bool IgnorePropierty { get; set; }
    }

    public class DataAccessParameter : Attribute
    {
        public DataAccessParameter(string nameParameter)
        {
            NameParameter = nameParameter;
        }
        public string NameParameter { get; set; }
    }
}
