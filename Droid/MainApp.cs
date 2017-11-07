using System;
using Android.App;
using Android.Runtime;
using Diabetes.localDB;
using Diabetes.Main;

namespace Diabetes.Droid
{
    [Application]
    public class MainApp : Application
    {
		ISetAlarm alarmService;
        public MainApp()
        {
        }

		
		
		public MainApp(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
		}

		public override void OnCreate()
		{


			base.OnCreate();
			MyLooper();
		}


		public void MyLooper()
		{
			try
			{
				alarmService = new SetAlarmImplementation();
				MedicationDatabase c = new MedicationDatabase();
				var alarm = c.GetAlarmList();
				var username = c.GetUserName();
				var hour = 0;
				var minute = 0;

				foreach (var list in alarm)
				{

					hour = Int32.Parse(list.Substring(0, 2));
					minute = Int32.Parse(list.Substring(3, 2));

					try
					{
						System.Diagnostics.Debug.WriteLine("Hour : " + hour + " Minutes : " + minute);
						alarmService.SetAlarm(hour, minute, "Diabetics App", "Hello  " + username + " , I remind you to take your insulin at this stated time");
					}
					catch (Exception e)
					{
						System.Diagnostics.Debug.WriteLine("Error  " + e);
					}

				}
			}
			catch (Exception f)
			{

			}

		}

    }
}
