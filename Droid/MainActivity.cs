using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Diabetes.localDB;
using Xamarin.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

using System.Threading.Tasks;
using Diabetes.Main;

namespace Diabetes.Droid
{
    [Activity(Label = "Diabetics App", Icon = "@drawable/ic_launcher", Theme = "@style/splashscreen", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public Handler mHandler;
        ISetAlarm alarmService;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //            ActionBar.Hide();
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);


           // MyLooper();

            LoadApplication(new App());
        }





    }
}
