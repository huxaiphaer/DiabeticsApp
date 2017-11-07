using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diabetes.localDB;
using Diabetes.Model;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class MasterPage : ContentPage
    {

        public ListView ListView { get { return listView; } }
        MedicationDatabase db = new MedicationDatabase();
        public MasterPage()
        {
            InitializeComponent();
            try
            {
                username.Text = db.GetUserName();
            }
            catch (Exception e)
            {

            }
            LoadNav();
        }

        public void LoadNav()
        {
            ObservableCollection<MasterPageItem> masterPageItems = new ObservableCollection<MasterPageItem>();
            masterPageItems.Add
                           (new MasterPageItem
                           {
                Title = AppResources.home_nav,
                               IconSource = "home_nav.png",
                               TargetType = typeof(HomeActivity)
                           });
            masterPageItems.Add
                           (new MasterPageItem
                           {
                Title = AppResources.therapy_nav,
                               IconSource = "checklist_nav.png",
                               TargetType = typeof(Therapy)
                           });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.trackme_nav,
                IconSource = "track_nav.png",
                TargetType = typeof(Track)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.settings_nav,
                IconSource = "settings_nav.png",
                TargetType = typeof(Settings)
            });
            listView.ItemsSource = masterPageItems;

        }
    }
}
