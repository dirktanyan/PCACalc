using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;
using System.IO;


[assembly: Xamarin.Forms.Dependency(typeof(PCACalc.Droid.DatabaseConnection_Android))]
namespace PCACalc.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection 
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "PCACalcDB.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);

            return new SQLiteConnection(path);
        }
    }
}