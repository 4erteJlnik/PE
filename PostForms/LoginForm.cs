using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE.PostForms
{
    public class LoginForm
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public LoginForm(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
