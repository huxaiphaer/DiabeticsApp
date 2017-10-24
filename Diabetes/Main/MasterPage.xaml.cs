using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diabetes.Model;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class MasterPage : ContentPage
    {

		public ListView ListView { get { return listView; } }
		public MasterPage()
		{
			InitializeComponent();
			LoadNav();
		}

		public void LoadNav()
		{
			ObservableCollection<MasterPageItem> masterPageItems = new ObservableCollection<MasterPageItem>();
			masterPageItems.Add
						   (new MasterPageItem
						   {
							   Title = "Home",
							   IconSource = "home_nav.png",
							   TargetType = typeof(HomeActivity)
						   });
			masterPageItems.Add
						   (new MasterPageItem
						   {
							   Title = "Therapy",
							   IconSource = "checklist_nav.png",
							   TargetType = typeof(Therapy)
						   });
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Track Me",
				IconSource = "track_nav.png",
				TargetType = typeof(Track)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Settings",
				IconSource = "settings_nav.png",
				TargetType = typeof(Settings)
			});
			listView.ItemsSource = masterPageItems;

		}
    }
}
