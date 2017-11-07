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
        MedicationDatabase db = new MedicationDatabase();
        MakeNotification notify = new MakeNotification();
        public App()
        {
            InitializeComponent();

           // notify.MakeAlarm();

            try
            {
                if (db.LoggedInStatus() != null && db.GetUserName()!=null)
                {
                    //MainPage = new NavigationPage(new ModalPushedEventArgs(MainActivity()));
                    MainPage = new NavigationPage(new MainActivity(""));
                   // MainPage = new ModalPushedEventArgs
                }

                else
                {
                    MainPage = new NavigationPage(new SignUp())

                    {
                        BarBackgroundColor = Color.FromHex("#66C8F3"),
                        BarTextColor = Color.White,
                        Title = "Diabetics App"
                    };
                }
            }
            catch (NullReferenceException es)
            {
                MainPage = new NavigationPage(new SignUp())

                {
                    BarBackgroundColor = Color.FromHex("#66C8F3"),
                    BarTextColor = Color.White,
                    Title = "Diabetics App"
                };
            }
            catch (ArgumentOutOfRangeException ew)
			{
				MainPage = new NavigationPage(new SignUp())

				{
					BarBackgroundColor = Color.FromHex("#66C8F3"),
					BarTextColor = Color.White,
					Title = "Diabetics App"
				};
			}
            catch (Exception ep)
            {
                MainPage = new NavigationPage(new SignUp())

                {
                    BarBackgroundColor = Color.FromHex("#66C8F3"),
                    BarTextColor = Color.White,
                    Title = "Diabetics App"
                };
            }


        }


        public async static Task NavigateToProfile(string message)
        {


            await App.Current.MainPage.Navigation.PushModalAsync(new MainActivity(message));
        }


       /* public async Type MyFirstPage(){

            return await await Navigation.PushAsync(new SignUp());
        }*/
        protected override void OnStart()
        {

            /* MakeNotification n = new MakeNotification();
             n.MakeAlarm();*/

        }


        protected override void OnSleep()
        {


            base.OnSleep();
			//notify.MakeAlarm();

        }

        protected override void OnResume()
        {
            // Handle when your app resumes

            base.OnResume();

        }






    }
}
