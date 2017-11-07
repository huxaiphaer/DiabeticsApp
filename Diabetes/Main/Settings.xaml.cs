using System;
using System.Collections.Generic;
using System.Diagnostics;
using Firebase.Database;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();

            if (Not_switchcell.IsEnabled)
            {
                try
                {
                    //https://medium.com/step-up-labs/firebase-c-library-5c342989ad18
                    DependencyService.Get<CancelNotifications>().CancelNotifications();
                }

                catch(Exception ex){
                    Debug.WriteLine("Error : "+ ex);
                }
                //DependencyService.Get<ISetAlarm>().SetAlarm(hour, min, "Diabetics App", "Hello i remind you to take medicine");
            }


            var firebase = new FirebaseClient("https://dinosaur-facts.firebaseio.com/");



        }

    }
}
