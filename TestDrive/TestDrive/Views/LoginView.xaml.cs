using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void Button_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<User>(new User(), "SuccessLogin");
        }
    }
}