using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class ListingVehicles
    {
            public List<Vehicle> Vehicles { get; set; }
        public ListingVehicles()
        {

            this.Vehicles = new List<Vehicle>()
            {
                new Vehicle { Name = "Azera V6", Price = 17000 },
                new Vehicle { Name = "Onix 1.6", Price = 7000 },
                new Vehicle { Name = "Fiesta 2.0", Price = 10400 },
                //new Vehicle { Name = "C3 1.0", Price = 4400 },
                //new Vehicle { Name = "Uno Fire", Price = 2200 },
                //new Vehicle { Name = "Sentra 2.0", Price = 10600 },
                //new Vehicle { Name = "Astra Sedan", Price = 7800 },
                //new Vehicle { Name = "Vectra 2.0 Turbo", Price = 7400 },
                //new Vehicle { Name = "Hilux 4x4", Price =   18000},
                //new Vehicle { Name = "Montana Cabine dupla", Price = 11400 },
                //new Vehicle { Name = "Outlander 2.4", Price = 19800 },
                //new Vehicle { Name = "Brasilia Amarela", Price = 1900 },
                //new Vehicle { Name = "Omega Hatch", Price = 1600 }
            };
        }
    }
}
