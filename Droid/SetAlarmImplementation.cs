using System;
using Android.App;
using Android.Content;
using Diabetes.Droid;
using Diabetes.localDB;
using Diabetes.Main;

[assembly: Xamarin.Forms.Dependency(typeof(SetAlarmImplementation))]
namespace Diabetes.Droid
{
    public class SetAlarmImplementation : ISetAlarm
    {

        public void SetAlarm()
        {

			MedicationDatabase db = new MedicationDatabase();
			var alarm_list = db.GetAlarmList();
            //Debug.WriteLine(" Time -- : "+ m.ToString());
            var title = "Diabetics App";
            var message = "Hello  we remind you of taking your inslin dosage now";
            foreach (var list in alarm_list)
            {

				var hour = Int32.Parse(list.Substring(0, 2));
				var minute = Int32.Parse(list.Substring(3, 2));
                Intent myintent = new Intent(Xamarin.Forms.Forms.Context, typeof(AlarmReceiver));
                myintent.PutExtra("message", message);
                myintent.PutExtra("title", title);
                PendingIntent pendingintent = PendingIntent.GetBroadcast(Xamarin.Forms.Forms.Context, 0, myintent, PendingIntentFlags.UpdateCurrent);

                Java.Util.Date date = new Java.Util.Date();
                Java.Util.Calendar cal = Java.Util.Calendar.Instance;
                cal.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
                cal.Set(Java.Util.CalendarField.HourOfDay, hour);
                cal.Set(Java.Util.CalendarField.Minute, minute);
                cal.Set(Java.Util.CalendarField.Second, 0);
                //	PendingIntent pendingIntent = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
                AlarmManager alarmManager = Xamarin.Forms.Forms.Context.GetSystemService(Android.Content.Context.AlarmService) as AlarmManager;
                alarmManager.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pendingintent);
            }
        }
    }
}
