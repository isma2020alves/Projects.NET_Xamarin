using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Login
    {
        public string Email { get;}
        public string Password { get; }
        public Login(string email,string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
