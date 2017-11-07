using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }
		async void onFacebook(object sender, System.EventArgs e)
		{
            await Navigation.PushAsync(new LoginFacebook());
		}

        async void   onGmail(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GmailLogin());
        }
    }
}
