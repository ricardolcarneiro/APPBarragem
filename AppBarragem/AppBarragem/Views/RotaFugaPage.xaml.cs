using AppBarragem.Infra;
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
	public partial class RotaFugaPage : ContentPage
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



        public RotaFugaPage()
		{
			InitializeComponent();
            TrackMeAsync();
            //mapaRotaFuga.MyLocationEnabled = true;
            //mapaRotaFuga.UiSettings.MyLocationButtonEnabled = true;

            //_pinTokyo.IsDraggable = true;
            //mapaRotaFuga.Pins.Add(_pinTokyo);
            //mapaRotaFuga.Pins.Add(_pinTokyo2);
            //mapaRotaFuga.SelectedPin = _pinTokyo;
            //mapaRotaFuga.MoveToRegion(MapSpan.FromCenterAndRadius(_pinTokyo.Position, Distance.FromMeters(5000)), true);


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
                //if (map.Pins.Count == 0)
                //{


                //    //lstUsuarioVO = new List<UsuarioVO>();
                //    //lstCuidador = new List<UsuarioVO>();
                //    //lstEnfermeiras = new List<UsuarioVO>();


                //    //lstUsuarioVO = new RestUsuario().RestGet();
                //    //lstCuidador = lstUsuarioVO.Where(i => i.Grupo_usuario_id == 51470639).ToList();
                //    //lstEnfermeiras = lstUsuarioVO.Where(i => i.Grupo_usuario_id == 16335373).ToList();

                //    //foreach (var item in lstCuidador)
                //    //{
                //    //    var pins = new Pin
                //    //    {
                //    //        Label = item.Nome,


                //    //        Icon = BitmapDescriptorFactory.FromBundle("pinRoxo.png"),
                //    //        Transparency = 3 / 10f,
                //    //        Flat = true
                //    //    };
                //    //    pins.Position = new Position(double.Parse(item.Latitude.Replace(".", ",")), double.Parse(item.Longitude.Replace(".", ",")));
                //    //    pins.Rotation = bearing;
                //    //    pins.Clicked += new EventHandler(ChamarCuidador);
                //    //    map.Pins.Add(pins);
                //    //}



                //    //foreach (var item in lstEnfermeiras)
                //    //{
                //    //    var pins = new Pin
                //    //    {
                //    //        Label = item.Nome,


                //    //        Icon = BitmapDescriptorFactory.FromBundle("pinEnfermagem.png"),
                //    //        Transparency = 3 / 10f,
                //    //        Flat = true
                //    //    };
                //    //    pins.Position = new Position(double.Parse(item.Latitude.Replace(".", ",")), double.Parse(item.Longitude.Replace(".", ",")));
                //    //    pins.Rotation = bearing;
                //    //    pins.Clicked += new EventHandler(ChamarEnfermagem);
                //    //    map.Pins.Add(pins);
                //    //}


                //    map.Pins.Add(pinsUsuario);
                //}

                mapaRotaFuga.Pins.Add(pinsUsuario);
                mapaRotaFuga.IsTrafficEnabled = true;
                mapaRotaFuga.IsShowingUser = true;
                mapaRotaFuga.IsIndoorEnabled = true;
                mapaRotaFuga.MyLocationEnabled = true;

                mapaRotaFuga.MoveCamera(CameraUpdateFactory.NewPosition(new Position(current.Latitude, current.Longitude)));


            });
        }

        private void ContentPage_LayoutChanged(object sender, EventArgs e)
        {
        
                TrackMeAsync();
     
        }
    }
}