using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Diabetes.Model;
using Xamarin.Forms;


namespace Diabetes.Main
{
    public partial class HomeActivity : ContentPage
    {
        
        public int Count = 0;
        public short Counter = 0;
        public int SlidePosition = 0;


        private HttpClient _client = new HttpClient();
        public ObservableCollection<Adverts> adverts;
        public HomeActivity()
        {
            InitializeComponent();
			MakeNotification n = new MakeNotification();
			n.MakeAlarm();

			//NavigationPage.SetHasNavigationBar(this, false);
		}

        protected  override async void OnAppearing()
        {

            try
            {
                

                adverts = new ObservableCollection<Adverts>();
                adverts.Add(
                     new Adverts
                     {
                         Title = "Contact Us and Advertise Here",
                         Image = "advertise_here.png"
                     });
                adverts.Add(new Adverts
                {
                    Title = "Don't forget to take medicine",
                    Image = "be_reminded.png"
                });
                adverts.Add(
                     new Adverts
                     {
                         Title = "Be yourself with zero worries",
                         Image = "be_you.png"
                     });
                adverts.Add(
                    new Adverts
                    {
                        Title = "Daily Diabetics Tips",
                        Image = "diabetes_tips.png"
                    });




                AdvertsCarousel.ItemsSource = adverts;
                // activity indicator visisbility is off .
                //App_activity_indicator.IsVisible = false;

                // attaching auto sliding on to carouselView 
                Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(7), () =>
                {
                    SlidePosition++;
                    if (SlidePosition == adverts.Count)
                        SlidePosition = 0;
                    AdvertsCarousel.Position = SlidePosition;
                    return true;
                });
            }
            catch (Exception ey)
            {
                Debug.WriteLine("" + ey);
            }

        }

       async void OnTherapy(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Therapy());
        }

       async  void OnTrack(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new Track());
        }
    }
}
