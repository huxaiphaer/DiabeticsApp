using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Support.V4.App;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using Android.Widget;
using Diabetes.localDB;
using Xamarin.Forms;

namespace Diabetes.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new string[] { "android.intent.action.BOOT_COMPLETED" }, Priority = (int)IntentFilterPriority.LowPriority)]
    public class AlarmReceiver : BroadcastReceiver 
    {



        public override void OnReceive(Context context, Intent intent)
        {


                var message = intent.GetStringExtra("message");
                var title = intent.GetStringExtra("title");
                Intent i = new Intent(context, typeof(AppStickyService));
                i.PutExtra("message", message);
                i.PutExtra("title", title);
                context.StartService(i);




        }
    }

    [BroadcastReceiver]
    [IntentFilter(new string[] { "TAKE", "SKIP" })]
    public class CustomActionReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            switch (intent.Action)
            {
                case "TAKE":
                    try
                    {
                        MedicationDatabase db = new MedicationDatabase();
                        db.addtracktaken("true");
                        Toast.MakeText(context, "DOSAGE TAKEN", ToastLength.Short).Show();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.StackTrace);
                    }
                    break;
                case "SKIP":
                    try
                    {
                        Toast.MakeText(context, "DOSAGE SKIPPED", ToastLength.Short).Show();
                        MedicationDatabase db = new MedicationDatabase();
                        db.addtrackmissed("true");
                        Toast.MakeText(context, "DOSAGE MISSED", ToastLength.Short).Show();
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.StackTrace);
                    }
                    break;
            }


        }
    }
}