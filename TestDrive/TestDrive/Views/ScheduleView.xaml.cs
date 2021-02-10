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
        public ScheduleView(Vehicle vehicle,User user)
        {
            InitializeComponent();
            this.ViewModel = new ScheduleViewModel(vehicle,user);
            this.BindingContext = this.ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Schedule>(this, "Schedule", async (msg) =>
              {
                  var confirm = await DisplayAlert("Confirm Schedule",
                      "Do you want to confirm the appointment?", "Yes", "No");

                  if (confirm)
                  {
                      this.ViewModel.SaveSchedule();
                  }
              });
            MessagingCenter.Subscribe<Schedule>(this, "SuccessSchedule",
                (msg) =>
                {
                    DisplayAlert("Schedule", "Schedule saved with success!", "ok");
                });
            MessagingCenter.Subscribe<ArgumentException>(this, "FailSchedule",
                (msg) =>
                {
                    DisplayAlert("Schedule", "Fail to schedule the test drive!" +
                        " Check your information and try again!", "ok");
                });
        }
          
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Schedule>(this, "Schedule");

            MessagingCenter.Unsubscribe<Schedule>(this, "SuccessSchedule");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "FailSchedule");
        }

    }
}
 