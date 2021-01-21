using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
  public class ListingViewModel
    {
        public List<Vehicle> Vehicles { get; set; }
        Vehicle vehicleSelected;
        public Vehicle VehicleSelected
        {
            get
            {
                return VehicleSelected = vehicleSelected;
            }
            set
            {
                vehicleSelected = value;
                if(value != null)
                MessagingCenter.Send(vehicleSelected, "VehicleSelected");
            }
        }
        public ListingViewModel()
        {
            this.Vehicles = new ListingVehicles().Vehicles;
        }
    }
}
