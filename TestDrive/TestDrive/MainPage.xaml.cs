using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive
{
    public class Vehicle
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    public partial class MainPage : ContentPage
    {
        public List<Vehicle> Vehicles { get; set; }

        public MainPage()
        {
            InitializeComponent();

            this.Vehicles = new List<Vehicle>()
            {
                new Vehicle { nome = "Azera V6", preco = 85000 },
                new Vehicle { nome = "Onix 1.6", preco = 35000 },
                new Vehicle { nome = "Fiesta 2.0", preco = 52000 },
                new Vehicle { nome = "C3 1.0", preco = 22000 },
                new Vehicle { nome = "Uno Fire", preco = 11000 },
                new Vehicle { nome = "Sentra 2.0", preco = 53000 },
                new Vehicle { nome = "Astra Sedan", preco = 39000 },
                new Vehicle { nome = "Vectra 2.0 Turbo", preco = 37000 },
                new Vehicle { nome = "Hilux 4x4", preco = 90000 },
                new Vehicle { nome = "Montana Cabine dupla", preco = 57000 },
                new Vehicle { nome = "Outlander 2.4", preco = 99000 },
                new Vehicle { nome = "Brasilia Amarela", preco = 9500 },
                new Vehicle { nome = "Omega Hatch", preco = 8000 }
            };

            this.BindingContext = this;
        }
    }
}
