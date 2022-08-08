using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinAppShortcuts
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppActions.OnAppAction += AppActions_OnAppAction;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        void AppActions_OnAppAction(object sender, AppActionEventArgs e)
        {
            if (Current != this && Current is App app)
            {
                AppActions.OnAppAction -= app.AppActions_OnAppAction;
                return;
            }
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.GoToAsync($"//{e.AppAction.Id}");
            });
        }
    }
}
