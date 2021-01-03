using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
    
namespace AppBarragem.Services
{

    public static class GeoLocalizacaoService
    {
        private static double[] dbGeo;

        static GeoLocalizacaoService()
        {

        }

        public static double[] EnviarLocalizacao(string address)
        {
            dbGeo = new double[2];

            var locationService = new GoogleLocationService("AIzaSyBKZp9cuEthSeBVTg51R2VYdebIyPIQwv8");

            var point = locationService.GetLatLongFromAddress(address);

            dbGeo[0] = point.Latitude;
            dbGeo[1] = point.Longitude;

            return dbGeo;

        }


    }
}