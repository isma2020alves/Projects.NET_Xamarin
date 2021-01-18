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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {

        public Vehicle Vehicle{ get; set; }
        public DetailView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.BindingContext = new DetailViewModel(vehicle);
        }

        private void buttonNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScheduleView(this.Vehicle));
        }

        
    }
}