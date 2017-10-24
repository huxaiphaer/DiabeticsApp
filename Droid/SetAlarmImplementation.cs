using System;
using Android.App;
using Android.Content;
using Diabetes.Droid;
using Diabetes.Main;

[assembly: Xamarin.Forms.Dependency(typeof(SetAlarmImplementation))]
namespace Diabetes.Droid
{
    public class SetAlarmImplementation : ISetAlarm
    {

        public void SetAlarm(int hour, int minute, string message,string title)
        {
            Intent myintent = new Intent(Xamarin.Forms.Forms.Context, typeof(AlarmReceiver));
			myintent.PutExtra("message", message);
			myintent.PutExtra("title", title);
            PendingIntent  pendingintent = PendingIntent.GetBroadcast(Xamarin.Forms.Forms.Context, 0, myintent, PendingIntentFlags.UpdateCurrent);

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
