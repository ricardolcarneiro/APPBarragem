using AppBarragem.Infra;
using AppBarragem.Infra.Rest;
using AppBarragem.VO;
using Plugin.Geolocator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace AppBarragem.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaPage : ContentPage
	{

        readonly Pin _pinTokyo = new Pin()
        {
            Type = PinType.Place,
            Label = "Tokyo SKYTREE",
            Address = "Sumida-ku, Tokyo, Japan",
            Position = new Position(35.71d, 139.81d)
        };


        readonly Pin _pinTokyo2 = new Pin()
        {
            Icon = BitmapDescriptorFactory.DefaultMarker(Color.Gray),
            Type = PinType.Place,
            Label = "Second Pin",
            Position = new Position(35.71d, 139.815d),
            ZIndex = 5
        };
        private List<RotaFuga> lstRotaFuga;

        public MapaPage ()
		{
			InitializeComponent ();
            TrackMeAsync();
            //map.MyLocationEnabled = true;
            //map.UiSettings.MyLocationButtonEnabled = true;

            //_pinTokyo.IsDraggable = true;
            //map.Pins.Add(_pinTokyo);
            //map.Pins.Add(_pinTokyo2);
            //map.SelectedPin = _pinTokyo;
            //map.MoveToRegion(MapSpan.FromCenterAndRadius(_pinTokyo.Position, Distance.FromMeters(5000)), true);


        }
        protected override void OnAppearing()
        {
            TrackMeAsync();
        }

        protected override void OnDisappearing()
        {
            TrackMeAsync();
        }


        private async void TrackMeAsync()
        {
            var current = await CrossGeolocator.Current.GetPositionAsync();
            current.Accuracy = 30;
            float bearing = float.Parse(current.Heading.ToString());


            var pinsUsuario = new Pin
            {
                Label = "Eu estou aqui",
                IsDraggable = true,
               Icon = BitmapDescriptorFactory.FromBundle("pinManopla.png"),
                Transparency = 3 / 10f,
                Flat = true
            };

          

            Device.BeginInvokeOnMainThread(() =>
            {


                pinsUsuario.Position = new Position(current.Latitude, current.Longitude);
                pinsUsuario.Rotation = bearing;
       

                    lstRotaFuga = new List<RotaFuga>();


                    lstRotaFuga = new RestRotaFuga().RestGet();
             
                    foreach (var item in lstRotaFuga)
                    {
                        var pins = new Pin
                        {
                            Label = item.Endereco,


                            Icon = BitmapDescriptorFactory.FromBundle("pinPontoEncontro.png"),
                            Transparency = 3 / 10f,
                            Flat = true
                        };
                        pins.Position = new Position(double.Parse(item.Latitude), double.Parse(item.Longitude));
                        pins.Rotation = bearing;
                        //pins.Clicked += new EventHandler(ChamarCuidador);
                        map.Pins.Add(pins);
                    }



                    //foreach (var item in lstEnfermeiras)
                    //{
                    //    var pins = new Pin
                    //    {
                    //        Label = item.Nome,


                    //        Icon = BitmapDescriptorFactory.FromBundle("pinEnfermagem.png"),
                    //        Transparency = 3 / 10f,
                    //        Flat = true
                    //    };
                    //    pins.Position = new Position(double.Parse(item.Latitude.Replace(".", ",")), double.Parse(item.Longitude.Replace(".", ",")));
                    //    pins.Rotation = bearing;
                    //    pins.Clicked += new EventHandler(ChamarEnfermagem);
                    //    map.Pins.Add(pins);
                    //}


                
                

                map.Pins.Add(pinsUsuario);
                map.IsTrafficEnabled = true;
                map.IsShowingUser = true;
                map.IsIndoorEnabled = true;
                map.MyLocationEnabled = true;

                map.MoveCamera(CameraUpdateFactory.NewPosition(new Position(current.Latitude, current.Longitude)));


            });
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
        
                TrackMeAsync();
     
        }
    }
}