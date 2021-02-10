using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {

        public Vehicle Vehicle{ get;}
        public User Usuario { get; }
        public DetailView(Vehicle vehicle, User user)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.Usuario = user;
            this.BindingContext = new DetailViewModel(vehicle);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "Next", (vehicle) =>
              {
                  Navigation.PushAsync(new ScheduleView(vehicle,this.Usuario));
              });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "Next");
        }
    }
}