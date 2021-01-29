using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;

namespace TestDrive.Views
{

    public partial class ListingView : ContentPage
    {
        public ListingViewModel ViewModel { get; set; }

        public ListingView()
        {
            InitializeComponent();
            this.ViewModel = new ListingViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "VehicleSelected", (msg) =>
              {
                  Navigation.PushAsync(new DetailView(msg));
              });
            await this.ViewModel.GetVehicles();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "VehicleSelected");

        }
    }
}