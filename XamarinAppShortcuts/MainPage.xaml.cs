using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace XamarinAppShortcuts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnAddShortcutClicked(object sender, EventArgs e)
        {
            try
            {
                await AppActions.SetAsync(
                    new AppAction("app_info", "App Info", icon: "info"),
                    new AppAction("app_notifications", "App Notifications", icon: "notification"));
            }
            catch (FeatureNotSupportedException ex)
            {
                Debug.WriteLine("App Actions not supported");
            }
        }
    }
}
