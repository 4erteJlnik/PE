using System;

namespace Web1.Infrastructure.Repository
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
                throw new Exception("Неверный адрес: " + Link.ToString());
            if (Login == null)
                throw new Exception("Отсутствует логин");
            else
                login = Login;
            if (Password == null)
                throw new Exception("Отсутствует пароль");
            else
                password = Password;
            ssl = usingSSL;
        }
        public FTPlink(string Link,bool usingSSL = false)
        {
            if (Link != null && Link != "")
                link = Link;
            else
                throw new Exception("Неверный адрес: " + Link.ToString());
            ssl = usingSSL;
        }

    }
}