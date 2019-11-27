using MenuApp.Droid;
using Model;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace MenuApp.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "menuApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }

    }
}