using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class DetailViewModel : BaseViewModel

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

        public DetailViewModel(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
            NextCommand = new Command(() =>
             {
                MessagingCenter.Send(vehicle, "Next");
             });
        }

        public ICommand NextCommand { get; set; }

    }
}
