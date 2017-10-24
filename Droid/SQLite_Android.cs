using System;
using System.IO;
using Diabetes.localDB;
using diabetics_app.Droid;

using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace diabetics_app.Droid
{
    public class SQLite_Android : ISQLite
    {
		public SQLite_Android()
		{
		}

		#region ISQLite implementation

		public SQLite.Net.SQLiteConnection GetConnection()
		{
			var fileName = "diabeticsdatabase.db3";
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, fileName);

			var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			var connection = new SQLite.Net.SQLiteConnection(platform, path);

			return connection;
		}

		#endregion
	}
}
