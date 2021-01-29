using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using static TestDrive.Views.LoginView;

namespace TestDrive
{
    public class LoginService
    {
        //string email = "joao@alura.com.br";
        //string password = "alura123";
        public async Task ToLogin(Login login)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var fillForm = new FormUrlEncodedContent(

                        new Dictionary<string, string>() {
                            { "email", login.Email },
                            { "senha", login.Password }
                });

                    client.BaseAddress = new Uri("https://aluracar.herokuapp.com/login");
                    var result = await client.PostAsync("/login", fillForm);
                    if (result.IsSuccessStatusCode)
                        MessagingCenter.Send<User>(new User(), "SuccessLogin");
                    else
                        MessagingCenter.Send<LoginException>(new LoginException("User or Password Incorrect!"), "FailLogin");

                }
            }
            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException("Connection Failed!" +
                    " Please check your internet connection and try again later!"), "FailLogin");
            }
        }
        public class LoginException : Exception
        {
            public LoginException(string message) : base(message)
            {
            }
        }
    }
}