using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.Infrastructure.Data
{
    public class FTPlink
    {
        /// <summary>
        /// адрес сервера
        /// </summary>
        /// <value>адрес</value>
        public string link { get; }
        public string password { get; }
        public string login { get; }
        public bool ssl { get; }
        public FTPlink(string Link, string Password, string Login, bool usingSSL = false)
        {
            if (Link != null && Link != "")
                link = Link;
            else
                throw new Exception("Wrong adress: " + Link.ToString());
            if (Login == null)
                throw new Exception("Login do not exist");
            else
                login = Login;
            if (Password == null)
                throw new Exception("Password do not exist");
            else
                password = Password;
            ssl = usingSSL;
        }
        public FTPlink(string Link, bool usingSSL = false)
        {
            if (Link != null && Link != "")
                link = Link;
            else
                throw new Exception("Wrong adress: " + Link.ToString());
            ssl = usingSSL;
        }

    }
}
