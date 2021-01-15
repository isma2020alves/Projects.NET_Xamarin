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
    public partial class ScheduleView : ContentPage
    {
        public Schedule Schedule { get; set; }

        public Vehicle Vehicle
        {
            get
            {
                return Schedule.Vehicle;
            }
            set
            {
                Schedule.Vehicle = value;
            }
        }
        public string FullName
        {
            get
            {
                return Schedule.FullName;
            }
            set
            {
                Schedule.FullName = value;
            }
        }

        public string MobileNumber
        {
            get
            {
                return Schedule.MobileNumber;
            }
            set
            {
                Schedule.MobileNumber = value;
            }
        }

        public string Email
        {
            get
            {
                return Schedule.Email;
            }
            set
            {
                Schedule.Email = value;
            }
        }

        public DateTime DateSchedule
        {
            get
            {
                return Schedule.DateSchedule;
            }
            set
            {
                Schedule.DateSchedule = value;
            }
        }

        public TimeSpan TimeSchedule
        {
            get
            {
                return Schedule.TimeSchedule;
            }
            set
            {
                Schedule.TimeSchedule = value;
            }
        }
        public ScheduleView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Schedule = new Schedule();
            this.Schedule.Vehicle = vehicle;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Schedule",
          string.Format(@"
        Vehicle: {0}
        Full Name: {1}
        Mobile Number: {2}
        E - Mail: {3}
        Date: {4}
        Time: {5}",
         Vehicle.Name , FullName, MobileNumber, Email, DateSchedule.ToString("dd/MM/yyyy"), TimeSchedule),
          "Confirm", "Cancel");
        }
    }
}