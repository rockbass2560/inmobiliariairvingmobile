using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControlCasaBO
{
    /// <summary>
    /// Interface basica para catalogo con ID y Descripcion
    /// </summary>
    public interface IResult
    {
        int ID { get; set; }
        string Descripcion { get; set; }
    }
    public interface ICasaResult
    {
        string TipoTransaccion { get; set; }
    }
}
