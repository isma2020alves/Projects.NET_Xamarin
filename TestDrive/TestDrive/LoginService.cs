using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive
{
    public class LoginService
    {
        //string email = "joao@alura.com.br";
        //string senha = "alura123";
        public async Task ToLogin(Login login)
        {
            using (var client = new HttpClient())
            {
                var fillForm = new FormUrlEncodedContent(

                    new Dictionary<string, string>() {
                            {"email", login.Email},
                            {"senha", login.Password}
            });

                client.BaseAddress = new Uri("https://aluracar.herokuapp.com/login");

                HttpResponseMessage result = null;
                try
                {
                    result = await client.PostAsync("/login", fillForm);
                }
                catch
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Connection Failed!" +
                        " Please check your internet connection and try again later!"), "FailLogin");
                }
                if (result.IsSuccessStatusCode)
                {
                    var contentResult = await result.Content.ReadAsStringAsync();

                    var resultLogin =
                         JsonConvert.DeserializeObject<ResultLogin>(contentResult);

                    MessagingCenter.Send<User>(resultLogin.usuario, "SuccessLogin");
                }
                else
                    MessagingCenter.Send<LoginException>(new LoginException("User or Password Incorrect!"), "FailLogin");
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