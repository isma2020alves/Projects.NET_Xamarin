using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Data
{
   public class ScheduleDAO
    {
        readonly SQLiteConnection connection;
        private List<Schedule> list;

        public List<Schedule> List
        {
            get
            {
                if (list == null)
                {
                    list = new List<Schedule>(connection.Table<Schedule>());
                }
                return list;
            }
            private set { list = value; }
        }

        public ScheduleDAO(SQLiteConnection connection)
        {
            this.connection = connection;
            this.connection.CreateTable<Schedule>();
        }

        public void Save(Schedule schedule)
        {
            if (this.connection.Find<Schedule>(schedule.ID) == null)
            {
                this.connection.Insert(schedule);
            }
            else
            {
                this.connection.Update(schedule);
            }
        }
    }
}
