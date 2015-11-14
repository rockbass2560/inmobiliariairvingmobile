using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using DataAccess;
using System.IO;

namespace ControlCasaBO
{
    public class Login
    {
        internal const string QueryLogin ="SELECT username FROM users where username='{0}' AND password='{1}'";
        public static bool Autenticar(string userName, string password)
        {
            bool returnValue=false;

            SHA1 encryptador = SHA1.Create();
            byte[] pass = Encoding.Unicode.GetBytes(password);
            byte[] passByte = encryptador.ComputeHash(pass,0,pass.Length);

            //string passEncriptado = System.Text.Encoding.Unicode.GetString(passByte);
            string passString = BitConverter.ToString(passByte).Replace("-", String.Empty);

            string queryFinal = String.Format(QueryLogin, userName, passString);

            DataAccessCommand command = new DataAccessCommand(queryFinal, System.Data.CommandType.Text);

            DataAccessDAO dao = DataAccessDAO.GetInstance();

            //int result = dao.ExecuteAction(command);

            object result = dao.GetFirstResult(command);

            if (result != null)
                returnValue = result.ToString().Equals(userName);

            return returnValue;
        }
    }
}
