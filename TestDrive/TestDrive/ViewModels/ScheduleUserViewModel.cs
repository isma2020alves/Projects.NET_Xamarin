using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestDrive.Data;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    class ScheduleUserViewModel : BaseViewModel
    {
        ObservableCollection<Schedule> list = new ObservableCollection<Schedule>();
        public ObservableCollection<Schedule> List
        {
            get
            {
                return list;
            }
            private set
            {
                list = value;
                OnPropertyChanged();
            }
        }
        public ScheduleUserViewModel()
        {
            using (var connection = DependencyService.Get<ISQLite>().GetConnection())
            {
                ScheduleDAO dao = new ScheduleDAO(connection);
                var listDB = dao.List;
                this.List.Clear();
                foreach (var itemDB in listDB)
                {
                    this.List.Add(itemDB);
                }
            }
        }
    }
}

