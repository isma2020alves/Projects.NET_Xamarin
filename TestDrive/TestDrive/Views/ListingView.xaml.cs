using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Views
{
    

    public partial class ListingView : ContentPage
    {
        public List<Vehicle> Vehicles { get; set; }
        public ListingView()
        {
            InitializeComponent();

            this.Vehicles = new ListingVehicles().Vehicles;
                  
            this.BindingContext = this;
        }

        private void listViewVehicles_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (Vehicle)e.Item;

            Navigation.PushAsync(new DetailView(vehicle));
        }
    }
}