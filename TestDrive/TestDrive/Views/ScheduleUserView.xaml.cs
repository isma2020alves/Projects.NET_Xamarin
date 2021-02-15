using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.Services;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScheduleUserView : ContentPage
    {
        readonly ScheduleUserViewModel _viewModel;
        public ScheduleUserView()
        {
            InitializeComponent();
            this._viewModel = new ScheduleUserViewModel();
            this.BindingContext = this._viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Schedule>(this, "ScheduleSelected",
                async (schedule) =>
                {
                    if (!schedule.Confirmed)
                    {
                        var resend = await DisplayAlert("Resend", "Do you want to send this appointment?", "Yes", "No");
                        if (resend)
                        {
                            ScheduleService scheduleService = new ScheduleService();
                            await scheduleService.SendSchedule(schedule);
                            this._viewModel.UpdateList();
                        }
                    }
                }   );
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Schedule>(this, "ScheduleSelected");
        }
    }
}