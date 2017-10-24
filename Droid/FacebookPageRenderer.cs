using System;
using Android.App;
using Diabetes.Droid;
using Diabetes.Main;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(LoginFacebook), typeof(FacebookPageRenderer))]
namespace Diabetes.Droid
{
    public class FacebookPageRenderer : PageRenderer
    {
        public FacebookPageRenderer()
        {

			// this is a ViewGroup - so should be able to load an AXML file and FindView<>
			var activity = this.Context as Activity;

			var auth = new OAuth2Authenticator(
				clientId: "134161603894277", // your OAuth2 client id
				scope: "", // The scopes for the particular API you're accessing. The format for this will vary by API.
				authorizeUrl: new Uri("https://www.facebook.com/v2.10/dialog/oauth/"), // the auth URL for the service
				redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")); // the redirect URL for the service

			auth.Completed += async (sender, eventArgs) => {
				if (eventArgs.IsAuthenticated)
				{
					var accesstoken = eventArgs.Account.Properties["access_token"].ToString();
					var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
					var expiryDate = DateTime.Now + TimeSpan.FromSeconds(expiresIn);
					var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null, eventArgs.Account);
					var response = await request.GetResponseAsync();
					var obj = JObject.Parse(response.GetResponseText());

					var id = obj["id"].ToString().Replace("\"", "");
					var name = obj["name"].ToString().Replace("\"", "");

					await App.NavigateToProfile(name);

				}
				else
				{
					// The user cancelled
					await App.NavigateToProfile(string.Format("Sorry, you didn't login successfully, try again please"));
				}
			};

			activity.StartActivity(auth.GetUI(activity));


        }
    }
}
