using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.ViewModels
{
  public class ListingViewModel
    {
        public List<Vehicle> Vehicles { get; set; }

        public ListingViewModel()
        {
            this.Vehicles = new ListingVehicles().Vehicles;
        }
    }
}
