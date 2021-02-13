using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using TestDrive.Media;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class MasterViewModel : BaseViewModel
    {
        public string Name
        {
            get { return this.user.nome; }
            private set
            {
                this.user.nome = value;
                OnPropertyChanged();
            }
        }

        public string DateBirth
        {
            get { return this.user.dataNascimento; }
            private set
            {
                this.user.dataNascimento = value;
                OnPropertyChanged();
            }

        }
        public string Mobile
        {
            get { return this.user.telefone; }
            private set
            {
                this.user.telefone = value;
                OnPropertyChanged();
            }

        }
        public string Email
        {
            get { return this.user.email; }
            private set
            {
                this.user.email = value;
                OnPropertyChanged();
            }
        }

        private bool editing = false;

        public bool Editing
        {
            get { return editing; }

            private set
            {
                editing = value;
                OnPropertyChanged();
            }
        }

        private ImageSource profilePhoto = "Profile_Image.png";

        public ImageSource ProfilePhoto
        {
            get { return profilePhoto; }

            private set
            {
                profilePhoto = value;
                OnPropertyChanged();
            }
        }

        private readonly User user;
        public ICommand EditProfileCommand { get; }
        public ICommand SaveProfileCommand { get; }
        public ICommand EditingCommand { get; }
        public ICommand TakePhotoCommand { get; }
        public ICommand MyAppointmentsCommand { get; }
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

            TakePhotoCommand = new Command(() =>
           {
               DependencyService.Get<ICamera>().TakePhoto();
           });

            MyAppointmentsCommand = new Command(() =>
            {
              MessagingCenter.Send<User>(user,"MyAppointments");
            });

            MessagingCenter.Subscribe<byte[]>(this, "TakePhoto",
                (bytes) =>
                {
                    ProfilePhoto = ImageSource.FromStream(
                        () => new MemoryStream(bytes));
                });
        }
    }
}