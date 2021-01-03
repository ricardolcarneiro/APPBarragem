using System;
using System.Collections.Generic;
using System.Text;
using AppBarragem.VO;
using RestSharp;
namespace AppBarragem.Infra.Rest
{
    public class RestMenu
    {
        public RestClient client = new RestClient(Constantes.GET_ENDERECO);
        public RestRequest request;

        public List<Menu> RestGet()
        {
            request = new RestRequest("Menu/", Method.GET);
            return client.Execute<List<Menu>>(request).Data;

        }

        public void RestPost(Menu item)
        {
            request = new RestRequest("Menu/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new Menu
            {
                Id = item.Id,
                Action  = item.Action,
                Activeli = item.Activeli,
                Area = item.Area,
                Controller = item.Controller,
                ImageClass = item.ImageClass,
                IsParent = item.IsParent,
                NameOption = item.NameOption,
                ParentId = item.ParentId,
                Status = item.Status
            });

            client.Execute(request);

        }

        public void RestDelete(Menu item)
        {


            request = new RestRequest("Menu/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, Menu item)
        {
            var request = new RestRequest("Menu/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public Menu RestGetID(Menu item)
        {
            request = new RestRequest("Menu/" + item.Id, Method.GET);
            return client.Execute<Menu>(request).Data;
        }
    }
    }