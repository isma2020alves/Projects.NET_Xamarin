using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel
    {
        public string Name
        {
            get { return this.user.nome; }
            set { this.user.nome= value; }
        }

        public string Email
        {
            get { return this.user.email; }
            set { this.user.email = value; }
        }
        private readonly User user;
        public ICommand EditProfileCommand { get; private set; }
        public MasterViewModel(User user)
        {
            this.user = user;

            EditProfileCommand = new Command(() =>
            {
                MessagingCenter.Send<User>(user,"EditProfile");
            });
        }
    }
}