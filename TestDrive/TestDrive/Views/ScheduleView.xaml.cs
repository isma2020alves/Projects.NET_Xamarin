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
        public ScheduleView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.BindingContext = this;
        }
    }
}