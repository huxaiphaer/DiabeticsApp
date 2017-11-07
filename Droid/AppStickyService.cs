using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Java.Util;

namespace Diabetes.Droid
{

	[Service(Exported = true, Name = "com.diabetics.Diabetes.AppStickyService")]
    public class AppStickyService : IntentService
	{

		public override void OnCreate()
		{
			base.OnCreate();
			Toast.MakeText(this, "..", ToastLength.Long).Show();

			System.Diagnostics.Debug.WriteLine("Sticky Service - Created");
		}

		public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
		{

            WireAlarm(intent);
          
			return StartCommandResult.Sticky;
		}

		public override Android.OS.IBinder OnBind(Android.Content.Intent intent)
		{
			System.Diagnostics.Debug.WriteLine("Sticky Service - Binded");
			Toast.MakeText(this, "Service started", ToastLength.Long).Show();

			return null;
		}

		public override void OnDestroy()
		{
			try
			{
				base.OnDestroy();

			}
			catch (Java.Lang.IllegalStateException ex)
			{
				//Log.Debug("MainActivity.OnDestroy", ex, "The activity was destroyed twice");
				System.Diagnostics.Debug.WriteLine("Sticky Service error "+ ex);
			}

			

		}


		private void cancelnotification(int id)
		{
			NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
			notificationManager.Cancel(id);
		}

		public void SetAlarm(int hour, int minute, string title, string message)
		{

			//AppContext.StartService(new Intent(AppContext, typeof(AppStickyService)));
			Intent myintent = new Intent(Android.App.Application.Context, typeof(AppStickyService));
			myintent.PutExtra("message", message);
			myintent.PutExtra("title", title);
			//PendingIntent pendingintent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, myintent, PendingIntentFlags.UpdateCurrent);
			PendingIntent pintent = PendingIntent.GetService(this, 0, new Intent(this, typeof(AppStickyService)), 0);

			Java.Util.Date date = new Java.Util.Date();
			Java.Util.Calendar cal = Java.Util.Calendar.Instance;
			cal.TimeInMillis = Java.Lang.JavaSystem.CurrentTimeMillis();
			cal.Set(Java.Util.CalendarField.HourOfDay, hour);
			cal.Set(Java.Util.CalendarField.Minute, minute);
			cal.Set(Java.Util.CalendarField.Second, 0);
			AlarmManager alarmManager = Android.App.Application.Context.GetSystemService(Android.Content.Context.AlarmService) as AlarmManager;
			alarmManager.Set(AlarmType.RtcWakeup, cal.TimeInMillis, pintent);
			Toast.MakeText(this, "Service started ", ToastLength.Long).Show();
		}


		public void WireAlarm(Intent intent)
		{
			//Show toast here
			//Toast.MakeText(context, "Hello it's me ", ToastLength.Short).Show();
			var message = intent.GetStringExtra("message");
			var title = intent.GetStringExtra("title");

			//Create intent for action 1 (TAKE)
			var actionIntent1 = new Intent();
			actionIntent1.SetAction("TAKE");
			var pIntent1 = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, actionIntent1, PendingIntentFlags.CancelCurrent);

			//Create intent for action 2 (REPLY)
			var actionIntent2 = new Intent();
			actionIntent2.SetAction("SKIP");
			var pIntent2 = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, actionIntent2, PendingIntentFlags.CancelCurrent);

			Intent resultIntent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(Android.App.Application.Context.PackageName);

			var contentIntent = PendingIntent.GetActivity(Android.App.Application.Context, 0, resultIntent, PendingIntentFlags.CancelCurrent);

			var pending = PendingIntent.GetActivity(Android.App.Application.Context, 0,
				resultIntent,
				PendingIntentFlags.CancelCurrent);

			//Debug.WriteLine(" Time -- : "+ m.ToString());


			// Instantiate the Big Text style:
			Notification.BigTextStyle textStyle = new Notification.BigTextStyle();


			var builder =
				new Notification.Builder(Android.App.Application.Context)
								.AddAction(Resource.Drawable.tick_notify, "TAKE", pIntent1)
								.AddAction(Resource.Drawable.cancel_notify, "SKIP", pIntent2)
								.SetSmallIcon(Resource.Drawable.ic_launcher)
								.SetContentTitle("Diabetics Reminder")
								.SetDefaults(NotificationDefaults.Sound)
								.SetStyle(new Notification
								.BigTextStyle()
								.SetSummaryText("")
								.SetBigContentTitle(title)
								.BigText(message)
			 ).SetDefaults(NotificationDefaults.All);

			builder.SetContentIntent(pending);

			var notification = builder.Build();


			var manager = NotificationManager.FromContext(Android.App.Application.Context);
			manager.Notify(10010, notification);
		}

        protected override void OnHandleIntent(Intent intent)
        {
            throw new NotImplementedException();
        }
    }
}
