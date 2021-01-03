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
            request = new RestRequest("Usuario/", Method.GET);
            return client.Execute<List<Usuario>>(request).Data;

        }

        public void RestPost(Usuario item)
        {
            request = new RestRequest("Usuario/", Method.POST);
            request.RequestFormat = DataFormat.Json;

            request.AddJsonBody(new Usuario
            {
                Id = item.Id,
                Bairro  = item.Bairro,
                Celular = item.Celular,
                Cep = item.Cep,
                Cidade = item.Cidade,
                Cpfcnpj = item.Cpfcnpj,
                DataNascimento = item.DataNascimento,
                Email = item.Email,
                Endereco = item.Endereco,
                Estado = item.Estado,
                FlagAtivo = item.FlagAtivo,
                Foto = item.Foto,
                GrupoUsuarioId = item.GrupoUsuarioId,
                Idade = item.Idade,
                Latitude = item.Latitude,
                Login = item.Login,
                Longitude = item.Longitude,
                Medicacaodiaria = item.Medicacaodiaria,
                Medico = item.Medico,
                Medicotelefone = item.Medicotelefone,
                Nome = item.Nome,
                Observacao = item.Observacao,
                Pessoacontato = item.Pessoacontato,
                Planosaude = item.Planosaude,
                Procedimentorotina = item.Procedimentorotina,
                Rg = item.Rg,
                Ranking = item.Ranking,
                Senha = item.Senha,
                Tiposaude = item.Tiposaude,
                Usuariocondicaoid = item.Usuariocondicaoid,
                UsuarioEspecialidadeId = item.UsuarioEspecialidadeId
               

            });

            client.Execute(request);

        }

        public void RestDelete(Usuario item)
        {


            request = new RestRequest("Usuario/{id}", Method.DELETE);
            request.AddParameter("id", item.Id);

            client.Execute(request);
        }
        public void RestUpdate(int id, Usuario item)
        {
            var request = new RestRequest("Usuario/" + id.ToString(), Method.PUT);
            request.AddJsonBody(item);
            client.Execute(request);
        }




        public Usuario RestGetID(Usuario item)
        {
            request = new RestRequest("Usuario/" + item.Id, Method.GET);
            return client.Execute<Usuario>(request).Data;
        }
    }
    }