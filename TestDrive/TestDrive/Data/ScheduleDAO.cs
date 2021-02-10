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
