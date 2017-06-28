using Com.OneSignal;
using Com.OneSignal.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyPushNotification
{
    public partial class App : Application
    {
        public NotificationReceived mReceivedDelegate;
        public NotificationOpened mOpenedDelegate;

        public App()
        {
            InitializeComponent();

            SetupPushDelegate();
            MainPage = new MyPushNotification.MyPushNotificationPage();

            OneSignal.Current.StartInit("e9bfbc59-fa56-48ed-bda0-93002c350641")
                 .InFocusDisplaying(OSInFocusDisplayOption.None)
                 .HandleNotificationReceived(mReceivedDelegate)
                 .HandleNotificationOpened(mOpenedDelegate)
                 .EndInit();


            OneSignal.Current.IdsAvailable((playerID, pushToken) =>
            {
                MyPushNotificationPage page = MainPage as MyPushNotificationPage;
                page.UpdateOneSignalID(playerID);
            });
        }

        void SetupPushDelegate()
        {
            mReceivedDelegate = delegate (OSNotification notification)
            {
                try
                {
                    Debug.WriteLine("OneSignal Notification Received:\nMessage: {0}", notification.payload.body);
                    Dictionary<string, object> additionalData = notification.payload.additionalData;
                    var newmessage = notification.payload.title + ": " + notification.payload.body;
                    MyPushNotificationPage page = MainPage as MyPushNotificationPage;
                    page.UpdateNewMessage(newmessage);
                    if (additionalData.Count > 0)
                        Debug.WriteLine("additionalData: {0}", additionalData);
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            };

            // Notification Opened Delegate
            mOpenedDelegate = delegate (OSNotificationOpenedResult result)
            {
                try
                {
                    Debug.WriteLine("OneSignal Notification opened:\nMessage: {0}", result.notification.payload.body);
                    Dictionary<string, object> additionalData = result.notification.payload.additionalData;
                    if (additionalData.Count > 0)
                        Debug.WriteLine("additionalData: {0}", additionalData);


                    List<Dictionary<string, object>> actionButtons = result.notification.payload.actionButtons;
                    if (actionButtons.Count > 0)
                        Debug.WriteLine("actionButtons: {0}", actionButtons);
                }
                catch (System.Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            };

        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
