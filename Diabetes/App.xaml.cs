using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Diabetes.localDB;
using Diabetes.Main;
using Newtonsoft.Json;
using Plugin.Notifications;
using Xamarin.Forms;

namespace Diabetes
{
    public partial class App : Application
    {

        public static bool IsInBackgrounded { get; private set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new SignUp())

            {
                BarBackgroundColor = Color.FromHex("#66C8F3"),
                BarTextColor = Color.White,
                Title = "Diabetics App"


            };
        }


		public async static Task NavigateToProfile(string message)
		{


            await App.Current.MainPage.Navigation.PushModalAsync(new MainActivity(message));
		}

        protected override void OnStart()
        {

           /* MakeNotification n = new MakeNotification();
            n.MakeAlarm();*/

        }


        protected override void OnSleep()
        {

            MakeNotification n = new MakeNotification();
            n.MakeAlarm();
            base.OnSleep();

        }

        protected override void OnResume()
        {
            // Handle when your app resumes

            base.OnResume();

        }





    }
}
