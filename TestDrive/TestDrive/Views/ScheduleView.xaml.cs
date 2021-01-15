using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleView : ContentPage
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
        public ScheduleView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
          DisplayAlert("Schedule",
        string.Format(@"
        Full Name: {0}
        Mobile Number: {1}
        E - Mail: {2}
        Date: {3}
        Time: {4}",
        FullName, MobileNumber, Email, DateSchedule.ToString("dd/MM/yyyy"),TimeSchedule),
        "Confirm", "Cancel");
        }
    }
}