using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    public partial class MasterView : TabbedPage
    {
        public MasterView(User user)
        {
            InitializeComponent();
            this.BindingContext = new MasterViewModel(user);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<User>(this,"EditProfile",
                (user)=>
            {
                this.CurrentPage = this.Children[1];
            });

            MessagingCenter.Subscribe<User>(this, "SuccessSaveProfile",
                (user) =>
                {
                    this.CurrentPage = this.Children[0];
                });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<User>(this, "EditProfile");

            MessagingCenter.Unsubscribe<User>(this, "SuccessSaveProfile");
        }

    }
}