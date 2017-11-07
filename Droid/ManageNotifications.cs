using System;
using Android.App;
using Android.Content;
using Diabetes.Main;

namespace Diabetes.Droid
{
    public class ManageNotifications : CancelNotifications
    {
        public ManageNotifications()
        {
        }

        public void CancelNotifications()
        {
            Intent intent = null;
			var extras = intent.Extras;

			if (extras != null && !extras.IsEmpty)
			{
                NotificationManager manager =Android.App.Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;
				var notificationId = extras.GetInt("NotificationIdKey", -1);
				if (notificationId != -1)
				{
					manager.Cancel(notificationId);
				}
			}
        }
    }
}
