using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBarragem.Views;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppBarragem
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new SplashPage();
        }

        protected override void OnStart()
        {
          
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
