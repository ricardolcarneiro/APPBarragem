
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using Jarvis.Utils;
//using Jarvis.Utils.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppBarragem.Services
{
    public static class FirebaseService
    {
        private static readonly IFirebaseConfig config;
        private static readonly IFirebaseClient client;

        //static FirebaseService()
        //{
        //    config = new FirebaseConfig
        //    {
        //        AuthSecret = "AIzaSyAmsau3mR2lkMisbgR3xsjIemoKoEHTRXA",
        //        BasePath = "https://deseo-gourmet-app.firebaseio.com/"
        //    };

        //    client = new FirebaseClient(config);
        //}
        static FirebaseService()
        {
            config = new FirebaseConfig
            {
                AuthSecret = "AIzaSyAmsau3mR2lkMisbgR3xsjIemoKoEHTRXA",
                BasePath = "https://barrage-1c56f.firebaseio.com/"
            };

            client = new FirebaseClient(config);
        }

        public static async Task EnviarLocalizacao(LocalizacaoFirebase localizacao)
        {
            await client.SetAsync($"usuario/{localizacao.Id}", localizacao);
        }

        public static async Task<List<LocalizacaoFirebase>> BuscarLocalizacao()
        {
            try
            {
                var result = await client.GetAsync("usuario");

                try
                {
                    var list = result.Body.Deserialize<List<LocalizacaoFirebase>>().Where(x => x != null).ToList();

                    return list;
                }
                catch
                {
                    var dic = result.Body.Deserialize<Dictionary<string, LocalizacaoFirebase>>();

                    var list = new List<LocalizacaoFirebase>();

                    foreach (var item in dic)
                    {
                        list.Add(item.Value);
                    }

                    return list;
                }
            }
            catch
            {
                return new List<LocalizacaoFirebase>();
            }
        }

        public static async Task<LocalizacaoFirebase> BuscarMaisProximo(double lat, double lng)
        {
            try
            {
                var result = await client.GetAsync("usuario");

                try
                {
                    var list = result.Body.Deserialize<List<LocalizacaoFirebase>>().Where(x => x != null).ToList();

                    list.ForEach(x => x.Distancia = new Haversine(lat, lng, x.Lat, x.Lng).ToKilometers().ToNumber().NumberToDouble());
                    list = list.OrderBy(x => x.Distancia).ToList();

                    return list.FirstOrDefault();
                }
                catch
                {
                    var dic = result.Body.Deserialize<Dictionary<string, LocalizacaoFirebase>>();

                    var list = new List<LocalizacaoFirebase>();

                    foreach (var item in dic)
                    {
                        list.Add(item.Value);
                    }

                    list.ForEach(x => x.Distancia = new Haversine(lat, lng, x.Lat, x.Lng).ToKilometers().ToNumber().NumberToDouble());
                    list = list.OrderBy(x => x.Distancia).ToList();

                    return list.FirstOrDefault();
                }
            }
            catch
            {
                return null;
            }
        }

        public static async Task DeletarTodos()
        {
            var result = await client.DeleteAsync("usuario");
        }

        public static async Task DeletarUm(int id)
        {
            var result = await client.DeleteAsync($"usuario/{id}");
        }
    }
}