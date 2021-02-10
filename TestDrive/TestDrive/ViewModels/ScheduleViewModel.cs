using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class ScheduleViewModel : BaseViewModel
    {
        const string URL_Post_Schedule = "https://aluracar.herokuapp.com/salvaragendamento";
        public Schedule Schedule { get; set; }

        public string Model
        {
            get { return this.Schedule.Model; }
            private set { this.Schedule.Model = value; }
        }

        public double Price
        {
            get { return this.Schedule.Price; }
            private set { this.Schedule.Price = value; }
        }


        public string FullName
        {
            get
            {
                return Schedule.FullName;
            }
            private set
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
            private set
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
            private set
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
            private set
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
            private set
            {
                Schedule.TimeSchedule = value;
            }
        }
        public ScheduleViewModel(Vehicle vehicle, User user)
        {
            this.Schedule = new Schedule(user.nome,user.telefone,user.email,vehicle.Name,vehicle.Price);

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
                carro = Model,
                preco = Price,
                dataAgendamento = dateTimeSchedule
            }
                );


            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URL_Post_Schedule, content);
            
            SaveScheduleDB();

            if (response.IsSuccessStatusCode)
                MessagingCenter.Send<Schedule>(this.Schedule, "SuccessSchedule");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailSchedule");
        }

        private void SaveScheduleDB()
        {
            using (var connection = DependencyService.Get<ISQLite>().GetConnection())
            {
                var dao = new ScheduleDAO(connection);
                dao.Save(new Schedule(FullName,MobileNumber,Email,Model, Price));
            }
        }
    }
}
