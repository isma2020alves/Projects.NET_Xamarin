﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDrive.Views;
using Xamarin.Forms;
using static TestDrive.Views.LoginView;

namespace TestDrive
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();  

            MainPage = new LoginView();
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<User>(this, "SuccessLogin",
                (user)=>
                {
                    MainPage = new NavigationPage(new ListingView());
                });

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
