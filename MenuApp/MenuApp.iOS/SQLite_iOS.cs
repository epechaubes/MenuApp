using MenuApp.iOS;
using Model;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace MenuApp.iOS
{
    class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {

        }

        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var fileName = "menuApp.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);
            return connection;
        }
    }
}