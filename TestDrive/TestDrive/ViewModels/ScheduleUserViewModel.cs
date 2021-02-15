using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        private Schedule scheduleSelected;

        public Schedule ScheduleSelected
        {
            get { return scheduleSelected; }
            set
            {
                if (value != null)
                {
                    scheduleSelected = value;
                    MessagingCenter.Send<Schedule>(scheduleSelected, "ScheduleSelected");
                }
            }

        }

        public ScheduleUserViewModel()
        {
            UpdateList();
        }

        public void UpdateList()
        {
            using (var connection = DependencyService.Get<ISQLite>().GetConnection())
            {
                ScheduleDAO dao = new ScheduleDAO(connection);
                var listDB = dao.List;

                var query =
                listDB
                    .OrderBy(l => l.DateSchedule)
                    .ThenBy(l => l.TimeSchedule);

                this.List.Clear();
                foreach (var itemDB in query)
                {
                    this.List.Add(itemDB);
                }
            }
        }
    }
}

