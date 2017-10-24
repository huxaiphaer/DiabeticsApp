using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Diabetes.Main
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new MainActivity(""));
		}

		async void onSignUp(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new SignUp());
		}
    }
}
