using System;
using Android.App;
using Android.Content;
using Diabetes.Droid;
using Diabetes.localDB;
using Diabetes.Main;


namespace Diabetes.Droid
{
    public class SetAlarmImplementation : ISetAlarm
    {

        public SetAlarmImplementation(){}


		public void SetAlarm(int hour, int minute, string title, string message)
		{


			Intent myintent = new Intent(Android.App.Application.Context, typeof(AlarmReceiver));
			myintent.PutExtra("message", message);
			myintent.PutExtra("title", title);
			PendingIntent pendingintent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, myintent, PendingIntentFlags.UpdateCurrent);

			Java.Util.Date date = new Java.Util.Date();
			Java.Util.Calendar cal = Java.Util.Calendar.Instance;
			cal.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
			cal.Set(Java.Util.CalendarField.HourOfDay, hour);
			cal.Set(Java.Util.CalendarField.Minute, minute);
			cal.Set(Java.Util.CalendarField.Second, 0);
			
			AlarmManager alarmManager = Android.App.Application.Context.GetSystemService(Android.Content.Context.AlarmService) as AlarmManager;
			alarmManager.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pendingintent);
		}
    }
}
