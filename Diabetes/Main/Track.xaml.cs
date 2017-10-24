using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Diabetes.localDB;
using Microcharts;
using SkiaSharp;
using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class Track : ContentPage
    {
        MedicationDatabase db = new MedicationDatabase();
        public Track()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
            var Taken_Nos = db.GetTracksTakenNos();
            var Missed_Nos = db.GetTracksMissedNo();
            var total = Taken_Nos + Missed_Nos;
            num_of_days.Text = "" + total;
            missed_label.Text = "" + Missed_Nos;
            taken_label.Text = "" + Taken_Nos;

        }



        protected override void OnAppearing()
        {


            var Taken_Nos = db.GetTracksTakenNos();
            var Missed_Nos = db.GetTracksMissedNo();
            //var myObservableCollectiontaken = new ObservableCollection<Track>(Taken);



            var entries = new[]{
                new Microcharts.Entry(Taken_Nos){
                    Label ="Taken",
                    ValueLabel =""+Taken_Nos,
                    Color =SKColor.Parse("#266489")
                },
                new Microcharts.Entry(Missed_Nos){
                    Label ="Missed",
                    ValueLabel =""+Missed_Nos,
                    Color =SKColor.Parse("#FF1493")
                }
            };


            var chart = new DonutChart() { Entries = entries };

            chartView.Chart = chart;
        }
    }
}
