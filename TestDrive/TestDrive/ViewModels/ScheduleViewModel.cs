using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
   public class ScheduleViewModel
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
        public ScheduleViewModel(Vehicle vehicle)
        {
            this.Schedule = new Schedule();
            this.Schedule.Vehicle = vehicle;

            CommandSchedule = new Command((msg) =>
                {
                    MessagingCenter.Send<Schedule>(this.Schedule, "Schedule");
                });
        }
        public ICommand CommandSchedule { get; set; }
    }
}
