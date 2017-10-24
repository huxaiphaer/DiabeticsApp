using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using Xamarin.Forms;

namespace Diabetes.localDB
{
    public class MedicationDatabase
    {
        private SQLiteConnection _connection;

        public MedicationDatabase()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Medication>();
            _connection.CreateTable<SetReminder>();
           // _connection.CreateTable<Track>();
            _connection.CreateTable<TrackMissed>();
            _connection.CreateTable<TrackTaken>();
        }
        public void AddDetails(string username, string alarm_time, string units, string insulin_type, string unique_id, string status)
        {

            _connection.Query<Medication>("Insert into [Medication] (username, alarm_time, units,insulin_type,unique_id,status) values" +
                                          "('" + username + "','" + alarm_time + "','" + units + "','" + insulin_type + "','" + unique_id + "','" + status + "')");

        }


        public void AddReminder(string username, string alarm_time,
                             string units, string insulin_type, string count_times)
        {

            _connection.Query<SetReminder>("Insert into [SetReminder] (username, alarm_time, units,insulin_type,count_times) values" +
                                          "('" + username + "','" + alarm_time + "','" + units
                                           + "','" + insulin_type + "','" + count_times + "')");
        }

        public IEnumerable<Medication> AllMedicationResults()
        {
            return (from t in _connection.Table<Medication>()
                    select t).ToList();
        }

        public IEnumerable<SetReminder> AllReminders()
        {
            return (from t in _connection.Table<SetReminder>()
                    select t).ToList();
        }

        public IEnumerable<string> GetAlarmList()
        {
            return (from t in _connection.Table<Medication>()
                    select t.alarm_time).ToList();
        }


        /* public string AlarmSample(){
			 return (_connection.Table<SetReminder>().Select(r => r.)
			.AsEnumerable()
					  .Select(r => r.Substring(1, r.Length - 2).Split(','))).ToList().ToString()
																			;        }*/

        public IEnumerable<string> GetUnitsList()
        {
            return (from t in _connection.Table<Medication>()
                    select t.units).ToList();
        }

        public void DeleteAlarm()
        {
            _connection.DeleteAll<SetReminder>();
        }


        public void DeleteTime(int id)
        {

            _connection.Delete<Medication>(id);
        }

        public void DeleteAllTime()
        {
            _connection.DeleteAll<Medication>();
        }

        // Tracking table 
        public void addtracktaken(string taken)
        {

            _connection.Query<TrackTaken>("Insert into [TrackTaken] (taken) values" +
                                          "('" + taken + "')");
        }

		public void addtrackmissed(string missed)
		{

            _connection.Query<TrackMissed>("Insert into [TrackMissed] (missed) values" +
                                           "('" + missed + "')");
		}

        public int  GetTracksTakenNos()
        {
            return (from t in _connection.Table<TrackTaken>()
                    select t.taken).Count();
        }

        public int GetTracksMissedNo()
        {
            return (from t in _connection.Table<TrackMissed>()
                    select t.missed).Count();
        }

    }
}
