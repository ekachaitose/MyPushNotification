using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyPushNotification
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPushNotificationPage : ContentPage
    {

        public MyPushNotificationPage()
        {
            InitializeComponent();
        }

        public void UpdateOneSignalID(string id)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                
                mOneSignalIDLabel.Text = id;
            });

        }

        public void UpdateNewMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                mNewMessageLabel.Text = message;
            });
        }
    }
}