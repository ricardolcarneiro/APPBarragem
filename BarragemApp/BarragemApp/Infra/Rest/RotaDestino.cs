using System;
using System.Collections.Generic;
using System.Text;
using AppBarragem.VO;
using RestSharp;
namespace AppBarragem.Infra.Rest
{
    public class RestRotaDestino
    {
        public RestClient client = new RestClient(Constantes.GET_ENDERECO);
        public RestRequest request;

        public List<RotaDestino> RestGet()
        {
            request = new RestRequest("RotaDestino/", Method.GET);
            return client.Execute<List<RotaDestino>>(request).Data;

        }

        public void RestPost(RotaDestino item)
        {
            request = new RestRequest("RotaDestino/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new RotaDestino
            {
                Id = item.Id,
                Data  = item.Data,
                UsuarioId = item.UsuarioId,
                Zoom = item.Zoom
                
            });

            client.Execute(request);

        }

        public void RestDelete(RotaDestino item)
        {


            request = new RestRequest("RotaDestino/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, RotaDestino item)
        {
            var request = new RestRequest("RotaDestino/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public RotaDestino RestGetID(RotaDestino item)
        {
            request = new RestRequest("RotaDestino/" + item.Id, Method.GET);
            return client.Execute<RotaDestino>(request).Data;
        }
    }
    }