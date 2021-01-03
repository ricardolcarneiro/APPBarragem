using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarragemApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashPage : ContentPage
	{
		public SplashPage ()
		{
			InitializeComponent ();

            if (CrossConnectivity.Current.IsConnected)
            {
       
                 Navigation.PushModalAsync(new NavigationPage(new MapaPage()));

            }
            else
            {
                DisplayAlert("AppBarrage Alerta!", "É necessario está conectado na internet", "Sair");
            }
        }
	}
}