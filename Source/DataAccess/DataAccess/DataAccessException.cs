using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    [Serializable()]
    public class DataAccessException : Exception
    {
        public DataAccessException(string message,Exception innerException, string property):base(message,innerException)
        {
            Property = property;
        }
        public string Property { get; set; }
        public string Parameter { get; set; }
    }
}
