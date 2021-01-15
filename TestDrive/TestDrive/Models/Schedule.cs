using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Schedule
    {
        public Vehicle Vehicle { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }

        DateTime dateSchedule = DateTime.Today;
        public DateTime DateSchedule
        {
            get
            {
                return dateSchedule;
            }
            set
            {
                dateSchedule = value;
            }
        }
        TimeSpan timeschedule;
        public TimeSpan TimeSchedule
        {
            get
            {
                return timeschedule;
            }
            set
            {
                timeschedule = value;
            }
        }

    }
}
