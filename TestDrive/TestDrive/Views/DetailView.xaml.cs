using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        public Vehicle Vehicle { get; set; }
        public string TextABS 
        { 
            get
            {
                return string.Format("Braking System ABS - $ {0}", Vehicle.ABS);
            }
        }
        public string TextAir_Cond 
        {
            get
            {
                return string.Format("Air Conditioning - $ {0}", Vehicle.Air_Cond);
            }            
        }
        public string TextGPS 
        {
            get
            {
                return string.Format("GPS - $ {0}", Vehicle.GPS);
            }
        }
        public bool OnABS
        {
            get 
            {
                return Vehicle.OnABS;
            }
            set
            {
                Vehicle.OnABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        public bool OnAirCond
        {
            get
            {
                return Vehicle.OnAirCond;
            }
            set
            {
                Vehicle.OnAirCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        public bool OnGPS
        {
            get
            {
                return Vehicle.OnGPS;
            }
            set
            {
                Vehicle.OnGPS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        public string TotalValue
            {
                get 
                {
                return Vehicle.TotalValueFormatted;
                }
            }
        
        
        public DetailView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.BindingContext = this;
        }

        private void buttonNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScheduleView(this.Vehicle));
        }

        
    }
}