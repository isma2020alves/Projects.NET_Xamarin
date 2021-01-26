using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        const string URL_Post_Schedule = "https://aluracar.herokuapp.com/salvaragendamento";
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
                OnPropertyChanged();
                ((Command)CommandSchedule).ChangeCanExecute();
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
                OnPropertyChanged();
                ((Command)CommandSchedule).ChangeCanExecute();
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
                OnPropertyChanged();
                ((Command)CommandSchedule).ChangeCanExecute();
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

            CommandSchedule = new Command(() =>
                {
                    MessagingCenter.Send<Schedule>(this.Schedule, "Schedule");
                }, () =>
                {
                    return !string.IsNullOrEmpty(this.FullName)
                    && !string.IsNullOrEmpty(this.MobileNumber)
                    && !string.IsNullOrEmpty(this.Email);
                });
        }
        public ICommand CommandSchedule { get; set; }
        public async void SaveSchedule()
        {
            HttpClient client = new HttpClient();

            var dateTimeSchedule = new DateTime(
                DateSchedule.Year, DateSchedule.Month, DateSchedule.Day,
                TimeSchedule.Hours, TimeSchedule.Minutes, TimeSchedule.Seconds);

            var json = JsonConvert.SerializeObject(new
            {

                nome = FullName,
                fone = MobileNumber,
                email = Email,
                carro = Vehicle.Name,
                preco = Vehicle.Price,
                dataAgendamento = dateTimeSchedule
            }
                );


            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var answer = await client.PostAsync(URL_Post_Schedule, content);
            if (answer.IsSuccessStatusCode)
                MessagingCenter.Send<Schedule>(this.Schedule, "SuccessSchedule");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailSchedule");
        }
    }
}
