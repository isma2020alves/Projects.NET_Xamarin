using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;
using static TestDrive.Views.LoginView;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        private string user;

        public string User
        {
            get { return user; }
            set
            {
                user = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                ((Command)LoginCommand).ChangeCanExecute();
            }
        }

        public ICommand LoginCommand { get; private set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.ToLogin(new Login(user,password));
            }, () =>
            {
                return !string.IsNullOrEmpty(User) &&
                 !string.IsNullOrEmpty(Password);

            });
        }
    }
}

