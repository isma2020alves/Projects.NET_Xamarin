using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        private const int ABS = 180;
        private const int Air_Cond = 150;
        private const int GPS = 140;
        public Vehicle Vehicle { get; set; }
        public string TextABS 
        { 
            get
            {
                return string.Format("Braking System ABS - $ {0}", ABS);
            }
        }
        public string TextAir_Cond 
        {
            get
            {
                return string.Format("Air Conditioning - $ {0}", Air_Cond);
            }            
        }
        public string TextGPS 
        {
            get
            {
                return string.Format("GPS - $ {0}", GPS);
            }
        }
        bool onABS;
        public bool OnABS
        {
            get 
            {
                return onABS;
            }
            set
            {
                onABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        bool onAirCond;
        public bool OnAirCond
        {
            get
            {
                return onAirCond;
            }
            set
            {
                onAirCond = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        bool onGPS;
        public bool OnGPS
        {
            get
            {
                return onGPS;
            }
            set
            {
                onGPS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TotalValue));
            }
        }
        public string TotalValue
        {
            get 
            {
                return string.Format("Final Price: $ {0}", 
                    Vehicle.Price 
                    + (OnABS ? ABS : 0)
                    + (OnAirCond ? Air_Cond : 0) 
                    + (OnGPS ? GPS : 0)
                    );
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