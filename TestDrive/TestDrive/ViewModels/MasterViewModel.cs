using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Name
        {
            get { return this.user.nome; }
            set { this.user.nome = value; }
        }

        public string DateBirth 
        {
            get { return this.user.dataNascimento; }
            set { this.user.dataNascimento = value; }
        }
        public string Mobile
        {
            get { return this.user.telefone; }
            set { this.user.telefone = value; }
        }
        public string Email
        {
            get { return this.user.email; }
            set { this.user.email = value; }
        }

        private bool editing = false;

        public bool Editing
        {
            get { return editing; }
            set { 
                editing = value;
                OnPropertyChanged(nameof(Editing));
            }
        }

        private readonly User user;
        public ICommand EditProfileCommand { get;}
        public ICommand SaveProfileCommand { get;}
        public ICommand EditingCommand { get; }
        public MasterViewModel(User user)
        {
            this.user = user;

            EditProfileCommand = new Command(() =>
            {
                MessagingCenter.Send<User>(user, "EditProfile");
            });

            SaveProfileCommand = new Command(() =>
            {
                MessagingCenter.Send<User>(user, "SuccessSaveProfile");
                this.Editing = false;
            });

            EditingCommand = new Command(() =>
            {
                this.Editing = true;
            });
        }
    }
}