using System;
using System.Collections.Generic;
using System.Text;
using AppBarragem.VO;
using RestSharp;


namespace AppBarragem.Infra.Rest
{
    public class RestUsuario
    {
        public RestClient client = new RestClient(Constantes.GET_ENDERECO);
        public RestRequest request;

        public List<Usuario> RestGet()
        {
            request = new RestRequest("API/Usuarios/", Method.GET);
            return client.Execute<List<Usuario>>(request).Data;

        }

        public void RestPost(Usuario item)
        {
            request = new RestRequest("API/Usuarios/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new Usuario
            {
                Id = item.Id,
                Bairro  = item.Bairro,
                Celular = item.Celular,
                Cep = item.Cep,
                Cidade = item.Cidade,
                Agencia = item.Agencia,
                Email = item.Email,
                Ativo = item.Ativo,
                Estado = item.Estado,
                Banco = item.Banco,
                Foto = item.Foto,
                Complemento = item.Complemento,
                Login = item.Login,
                Conta = item.Conta,
                Nome = item.Nome,
                Cpf = item.Cpf,
                DataAtualizacao = item.DataAtualizacao,
                Senha = item.Senha,
                DataCriacao = item.DataCriacao,
                Digito = item.Digito,
                Numero = item.Numero,
                PlayerId = item.PlayerId,
                Rua = item.Rua,
                StatusCadastro = item.StatusCadastro,
                TipoUsuario = item.TipoUsuario,
                UrlFotoCnh = item.UrlFotoCnh,
                UrlFotoSelfie = item.UrlFotoSelfie
            });

            client.Execute(request);

        }

        public void RestDelete(Usuario item)
        {


            request = new RestRequest("API/Usuarios/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, Usuario item)
        {
            var request = new RestRequest("API/Usuarios/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public Usuario RestGetID(Usuario item)
        {
            request = new RestRequest("API/Usuarios/" + item.Id, Method.GET);
            return client.Execute<Usuario>(request).Data;
        }
    }
    }