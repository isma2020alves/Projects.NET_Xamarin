using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
    class ScheduleService
    {
        const string URL_Post_Schedule = "https://aluracar.herokuapp.com/salvaragendamento";

        public async Task SendSchedule(Schedule schedule)
        {
            HttpClient client = new HttpClient();

            var dateTimeSchedule = new DateTime(
                schedule.DateSchedule.Year, schedule.DateSchedule.Month, schedule.DateSchedule.Day,
                schedule.TimeSchedule.Hours, schedule.TimeSchedule.Minutes, schedule.TimeSchedule.Seconds);

            var json = JsonConvert.SerializeObject(new
            {

                nome = schedule.FullName,
                fone = schedule.MobileNumber,
                email = schedule.Email,
                carro = schedule.Model,
                preco = schedule.Price,
                dataAgendamento = dateTimeSchedule
            }
                );


            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(URL_Post_Schedule, content);
            schedule.Confirmed = response.IsSuccessStatusCode;
            SaveScheduleDB(schedule);

            if (schedule.Confirmed)
                MessagingCenter.Send<Schedule>(schedule, "SuccessSchedule");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FailSchedule");
        }

        private void SaveScheduleDB(Schedule schedule)
        {
            using (var connection = DependencyService.Get<ISQLite>().GetConnection())
            {
                var dao = new ScheduleDAO(connection);
                dao.Save(new Schedule(schedule.FullName, schedule.MobileNumber, schedule.Email, schedule.Model, schedule.Price, schedule.DateSchedule, schedule.TimeSchedule, schedule.Confirmed));
            }
        }

    }

}
