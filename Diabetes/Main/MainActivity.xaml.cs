using System;
using System.Collections.Generic;
using Diabetes.Model;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class MainActivity : MasterDetailPage
    {
        public MainActivity(string message)
        {
            InitializeComponent();
			masterPage.ListView.ItemSelected += OnItemSelected;
			

		}


		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}
    }
}
