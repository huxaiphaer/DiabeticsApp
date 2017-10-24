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
namespace Diabetes.Droid
{
    [Activity(Label = "diabetics_app.Droid", Icon = "@drawable/ic_launcher", Theme = "@style/splashscreen", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //            ActionBar.Hide();
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
			//Xamarin.Forms.Init();
           
            LoadApplication(new App());
        }

    }
}
