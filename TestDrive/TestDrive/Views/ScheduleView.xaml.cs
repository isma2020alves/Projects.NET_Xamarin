using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    public partial class ScheduleView : ContentPage
    {
        public ScheduleViewModel ViewModel { get; set; }
        public ScheduleView(Vehicle vehicle)
        {
            InitializeComponent();
            this.ViewModel = new ScheduleViewModel(vehicle);
            this.BindingContext = this.ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Schedule>(this, "Schedule", (msg) =>
              {
                  DisplayAlert("Schedule",
                string.Format(@"
        Vehicle: {0}
        Full Name: {1}
        Mobile Number: {2}
        E - Mail: {3}
        Date: {4}
        Time: {5}",
               ViewModel.Vehicle.Name, ViewModel.FullName, ViewModel.MobileNumber, ViewModel.Email, ViewModel.DateSchedule.ToString("dd/MM/yyyy"), ViewModel.TimeSchedule),
                "Confirm", "Cancel");
              });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Schedule>(this, "Schedule");
        }

    }
}