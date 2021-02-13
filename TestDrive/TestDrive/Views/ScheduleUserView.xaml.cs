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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleUserView : ContentPage
    {
        public ScheduleUserView()
        {
            InitializeComponent();

            this.listviewAppointments.ItemsSource = new List<Schedule>
            {
                new Schedule("Mary","0800","mary@gmail.com","Azira 2.0",30000,
                new DateTime(2021,02,28),new TimeSpan(16,30,0))
            };
        }
    }
}