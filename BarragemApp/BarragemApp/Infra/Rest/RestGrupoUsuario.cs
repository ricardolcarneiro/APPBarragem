using System;
using System.Collections.Generic;
using System.Text;
using AppBarragem.VO;
using RestSharp;
namespace AppBarragem.Infra.Rest
{
    public class RestGrupoUsuario
    {
        public RestClient client = new RestClient(Constantes.GET_ENDERECO);
        public RestRequest request;

        public List<GrupoUsuario> RestGet()
        {
            request = new RestRequest("GrupoUsuario/", Method.GET);
            return client.Execute<List<GrupoUsuario>>(request).Data;

        }

        public void RestPost(GrupoUsuario item)
        {
            request = new RestRequest("GrupoUsuario/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new GrupoUsuario
            {
                Id = item.Id,
                Descricao  = item.Descricao
                
            });

            client.Execute(request);

        }

        public void RestDelete(GrupoUsuario item)
        {


            request = new RestRequest("GrupoUsuario/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, GrupoUsuario item)
        {
            var request = new RestRequest("GrupoUsuario/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public GrupoUsuario RestGetID(GrupoUsuario item)
        {
            request = new RestRequest("GrupoUsuario/" + item.Id, Method.GET);
            return client.Execute<GrupoUsuario>(request).Data;
        }
    }
    }