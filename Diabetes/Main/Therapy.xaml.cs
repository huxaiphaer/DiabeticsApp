using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diabetes.localDB;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class Therapy : ContentPage
    {
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;
        int heightRowsList = 90;
        public Therapy()
        {
            InitializeComponent();
			//NavigationPage.SetHasNavigationBar(this, false);
			MakeNotification n = new MakeNotification();
			n.MakeAlarm();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            MedicationDatabase db = new MedicationDatabase();
            var medical_lis = db.AllReminders();
            ObservableCollection<SetReminder> trends = new ObservableCollection<SetReminder>(medical_lis);
            reminder_lv.ItemsSource = trends;
            int i = trends.Count;
            i = (trends.Count * heightRowsList);
            reminder_lv.HeightRequest = i;


        }

        public void RefreshList()
        {

            MedicationDatabase db = new MedicationDatabase();
            var medical_lis = db.AllReminders();
            ObservableCollection<SetReminder> trends = new ObservableCollection<SetReminder>(medical_lis);
            reminder_lv.ItemsSource = trends;
            int i = trends.Count;
            i = (trends.Count * heightRowsList);
            reminder_lv.HeightRequest = i;

        }

        async void Handle_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddReminder());
        }


        void OnDeleteTimeSet(object sender, System.EventArgs e)
        {
          
            MedicationDatabase db = new MedicationDatabase();
            db.DeleteAlarm();
			db.DeleteAllTime();
			RefreshList();
          

        }
    }
}
