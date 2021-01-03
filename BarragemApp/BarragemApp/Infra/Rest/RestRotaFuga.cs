using System;
using System.Collections.Generic;
using System.Text;
using AppBarragem.Infra;
using AppBarragem.VO;
using RestSharp;
namespace BarragemApp.Infra.Rest
{
    public class RestRotaFuga
    {
        public RestClient client = new RestClient(Constantes.GET_ENDERECO);
        public RestRequest request;

        public List<RotaFuga> RestGet()
        {
            request = new RestRequest("API/RotaFugas/", Method.GET);
            return client.Execute<List<RotaFuga>>(request).Data;

        }

        public void RestPost(RotaFuga item)
        {
            request = new RestRequest("API/RotaFugas/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new RotaFuga
            {
                Id = item.Id,
                Data  = item.Data,
                UsuarioId = item.UsuarioId,
                Zoom = item.Zoom
                
            });

            client.Execute(request);

        }

        public void RestDelete(RotaFuga item)
        {


            request = new RestRequest("API/RotaFugas/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, RotaFuga item)
        {
            var request = new RestRequest("API/RotaFugas/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public RotaFuga RestGetID(RotaFuga item)
        {
            request = new RestRequest("API/RotaFugas/" + item.Id, Method.GET);
            return client.Execute<RotaFuga>(request).Data;
        }
    }
    }