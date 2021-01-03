using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Barrage.Services;
using App.Barrage.Views;

namespace App.Barrage
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
    }
}
