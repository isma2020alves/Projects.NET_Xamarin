using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static TestDrive.LoginService;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public class User
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
        public class LoginResult
        {
            public User user { get; set; }
        }
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<LoginException>(this, "FailLogin",
                async (exc) =>
                {
                    await DisplayAlert("Login", exc.Message, "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<LoginException>(this, "FailLogin");
        }

    }
}