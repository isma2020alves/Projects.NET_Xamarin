using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestDrive.Data;
using TestDrive.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]

namespace TestDrive.Droid
{
    class SQLite_android : ISQLite
    {
        private const string fileNameDB = "Schedule.db3";

        public SQLiteConnection GetConnection()
        {
            var pathDB =  Path.Combine(Android.OS.Environment.ExternalStorageDirectory.Path,
                fileNameDB);

            return new SQLite.SQLiteConnection(pathDB);
        }
    }
}