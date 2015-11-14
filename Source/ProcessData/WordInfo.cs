using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessData
{
    public class WordInfo
    {
        private const string WhiteSpace = " ";

        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public long Credito { get; set; }

        public string DireccionCompleta
        {
            get { return Calle + WhiteSpace + Colonia; }
        }
    }
}
