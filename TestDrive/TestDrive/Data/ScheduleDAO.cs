using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrive.Models;

namespace TestDrive.Data
{
    class ScheduleDAO
    {
        readonly SQLiteConnection connection;
        private List<Schedule> list;

        public List<Schedule> List
        {
            get
            {
                return connection.Table<Schedule>().ToList();
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
            connection.Insert(schedule);
        }
    }
}
