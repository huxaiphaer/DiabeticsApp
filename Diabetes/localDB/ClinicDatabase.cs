using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;

namespace Diabetes.localDB
{
    public class ClinicDatabase
    {
		private SQLiteConnection _connection;
        public ClinicDatabase()
        {
		
        }

		public IEnumerable<string> GetAlarmList()
		{
			return (from t in _connection.Table<Medication>()
					select t.alarm_time).ToList();
		}
    }
}
