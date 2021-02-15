using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class Schedule
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

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
        TimeSpan timeSchedule;
        public TimeSpan TimeSchedule
        {
            get
            {
                return timeSchedule;
            }
            set
            {
                timeSchedule = value;
            }
        }
        public string DateFormatted
        {
            get
            {
                return DateSchedule.Add(timeSchedule)
                    .ToString("dd/MM/yyyy HH:mm");
            }
        }
        public Schedule()
        {

        }
        public Schedule(string fullName, string mobileNumber, string email, string model, double price, DateTime dateSchedule, TimeSpan timeSchedule)
            : this(fullName, mobileNumber, email, model, price)
        {

            this.DateSchedule = dateSchedule;
            this.TimeSchedule = timeSchedule;
        }
        public Schedule(string fullName, string mobileNumber, string email, string model, double price)
        {
            this.FullName = fullName;
            this.MobileNumber = mobileNumber;
            this.Email = email;
            this.Model = model;
            this.Price = price;
        }
    }
}
