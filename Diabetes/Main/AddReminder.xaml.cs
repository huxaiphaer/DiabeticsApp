using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diabetes.localDB;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class AddReminder : ContentPage
    {
		public int Count = 0;
		public short Counter = 0;
		public int SlidePosition = 0;
		string heightList;
		int heightRowsList = 90;

		public AddReminder()
		{
			InitializeComponent();

			string[] List ={ "1 milliliter","2 milliliters","3 milliliters","4 milliliters","5 milliliters","6 milliliters",
				"7 milliliters","8 milliliters","9 milliliters","10 milliliters"};
			measurements_pk.ItemsSource = List;
		}


		public async void StoreLocally()
		{
			try
			{
				string insulintype = inulin_type_entry.Text;
				var alarmtime = time_pk.Time.ToString();
				string units = measurements_pk.SelectedItem.ToString();
				string username = "Musa";
				string unique_no = "YTRU3747473b";
				string status = "true";
				MedicationDatabase db = new MedicationDatabase();
				if (insulintype != "")
				{
					if (insulintype != "")
					{
						try
						{
							db.AddDetails("musa", alarmtime, units, insulintype, unique_no, status);
						}
						catch (NullReferenceException ev)
						{
							await DisplayAlert("Hey!", "Insert the insulin type please!!", "OK");
						}
					}
					else
					{
						await DisplayAlert("Hey!", "Make sure all fields are not empty or un selected ", "OK");
					}
				}
				else
				{
					await DisplayAlert("Hey!", "Insert the insulin type please!!", "OK");
				}
			}
			catch (NullReferenceException r)
			{
				await DisplayAlert("Hey!", "Make sure all fields are not empty or un selected ", "OK");

			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			MedicationDatabase db = new MedicationDatabase();
			var medical_lis = db.AllMedicationResults();
			ObservableCollection<Medication> trends = new ObservableCollection<Medication>(medical_lis);
			set_time_lv.ItemsSource = trends;
			int i = trends.Count;
			i = (trends.Count * heightRowsList);
			set_time_lv.HeightRequest = i;


		}

		public void RefreshList()
		{

			MedicationDatabase db = new MedicationDatabase();
			var medical_lis = db.AllMedicationResults();
			ObservableCollection<Medication> trends = new ObservableCollection<Medication>(medical_lis);
			//ObservableCollection<> t = new ObservableCollection<>();
			set_time_lv.ItemsSource = trends;
			int i = trends.Count;
			i = (trends.Count * heightRowsList);
			set_time_lv.HeightRequest = i;

		}

		async void onAddDetails(object sender, System.EventArgs e)
		{
			try
			{
				StoreLocally();
				RefreshList();
			}

			catch (NullReferenceException ex)
			{
				await DisplayAlert("Hey!", "Make sure all fields are not empty or un selected ", "OK");
			}
		}



		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{

			var medic = e.SelectedItem as Medication;
			MedicationDatabase db = new MedicationDatabase();
			db.DeleteTime(medic.ID);
			RefreshList();

		}

		async void onSave(object sender, System.EventArgs e)
		{
			try
			{
				MedicationDatabase db = new MedicationDatabase();
				string insulintype = inulin_type_entry.Text;
				var alarmtime = time_pk.Time.ToString();
				string units = measurements_pk.SelectedItem.ToString();
				string username = "Musa";
				string unique_no = "YTRU3747473b";
				string status = "true";
				var units_list = db.GetUnitsList();
				var alarm_list = db.GetAlarmList();
				var alarm_result = JsonConvert.SerializeObject(alarm_list);
                var units_result = JsonConvert.SerializeObject(units_list);
				//await DisplayAlert("", "" + alarm_result, "Ok");


                db.DeleteAlarm();
				db.AddReminder(username, alarm_result, units_result, insulintype, "2");
				Navigation.PopAsync();
			}
			catch (NullReferenceException f)
			{  
				await DisplayAlert("Hey!", "Hey please select the measurements!!", "OK");
			}


		}
    }
}
