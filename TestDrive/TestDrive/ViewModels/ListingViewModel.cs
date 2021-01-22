using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ListingViewModel : BaseViewModel
    {
        const string URL_Get_Vehicles = "https://aluracar.herokuapp.com/";
        public ObservableCollection<Vehicle> Vehicles { get; set; }
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
                if (value != null)
                    MessagingCenter.Send(vehicleSelected, "VehicleSelected");
            }
        }

        private bool loading;

        public bool Loading
        {
            get { return loading; }
            set 
            { 
                loading = value;
                OnPropertyChanged();
            }
        }

        public ListingViewModel()
        {
            this.Vehicles = new ObservableCollection<Vehicle>();
        }
        public async Task GetVehicles()
        {
            Loading = true;
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync(URL_Get_Vehicles);

            var vehiclesJson = JsonConvert.DeserializeObject<VehicleJson[]>(result);

            foreach (var vehicleJson in vehiclesJson)
            {
                this.Vehicles.Add(new Vehicle
                {
                    Name = vehicleJson.nome,
                    Price = vehicleJson.preco
                }); 
            }
            Loading = false;
        }
    }

    class VehicleJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }
}
