using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppBarragem.API.Controllers
{
    [APIAuthorize]
    public class HomeController : ApiController
    {
        private readonly DatabaseContext db;
        private readonly d<Praca> pracas;
        private readonly Repository<Categoria> categorias;
        private readonly Repository<Produto> produtos;
        private readonly Repository<DAL.Context.ProdutoPedido> produtos_pedido;
        private readonly Repository<Configuracao> configuracao;
        private readonly Repository<Cartao> cartoes;
        private readonly Repository<Pedido> pedidos;
        private readonly Repository<Cupom> cupons;
        private readonly Repository<Localizacao> localizacoes;
        public HomeController()
        {
            db = new DatabaseContext();
            pracas = new Repository<Praca>(db);
            categorias = new Repository<Categoria>(db);
            produtos = new Repository<Produto>(db);
            produtos_pedido = new Repository<DAL.Context.ProdutoPedido>(db);
            configuracao = new Repository<Configuracao>(db);
            cartoes = new Repository<Cartao>(db);
            pedidos = new Repository<Pedido>(db);
            cupons = new Repository<Cupom>(db);
            localizacoes = new Repository<Localizacao>(db);
        }
    }
}
