using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive;
using TestDrive.Models;
using TestDrive.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    public partial class MasterDetailView : MasterDetailPage
    {
        private readonly User user;

        public MasterDetailView(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Master = new MasterView(user);
            this.Detail = new NavigationPage(new ListingView(user));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<User>(this, "MyAppointments",
                (user) =>
                {
                    this.Detail = new NavigationPage( 
                    new ScheduleUserView());
                    this.IsPresented = false;
                });

            MessagingCenter.Subscribe<User>(this, "NewSchedule",
                (user) =>
                {
                    this.Detail = new NavigationPage(new ListingView(user));
                    this.IsPresented = false;
                });
    }
            protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<User>(this, "MyAppointments");

            MessagingCenter.Unsubscribe<User>(this, "NewSchedule");
        }
    }
}